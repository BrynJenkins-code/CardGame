using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BoardHandler : MonoBehaviour
{

    private GameManager GameManager; 
    private Dictionary<string, CardHandler> Hand = new Dictionary<string, CardHandler>();

    /// <summary>
    /// Variables for handling card placements. 
    /// </summary>
    private Dictionary<GameObject, CardHandler> CardSlotsPos = new Dictionary<GameObject, CardHandler>();  
    public int CardSlots; 
    public float minPlayDistance = 10f; 

    public GameObject prefab; 
    // Start is called before the first frame update
    void Start()
    {
        GameManager = gameObject.GetComponent<GameManager>();
        SetupBoard(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// This code is duplicated in PlayerController, maybe make a common method in some helper class for code cleanliness 
    /// </summary>
    private void SetupBoard()
    {
        float boardWidth = 0; 
        if (TryGetComponent<Renderer>(out Renderer renderer))
        {
            boardWidth = renderer.bounds.size.x;
        }
        else
        {
            boardWidth = 2f; // fallback value
        }

        Vector3 originalScale = prefab.transform.localScale;
                    // Preserve the original aspect ratio while scaling to the new width
        float slotWidth = boardWidth / (CardSlots * 1.2f);
        float slotSpacing = slotWidth *1.5f;
        float scaleMultiplier = slotWidth / originalScale.x;
        for (int i = 0; i < CardSlots; i++)
        {   
            GameObject newPos = GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity); 
            
            newPos.transform.localScale = new Vector3(
                originalScale.x * scaleMultiplier,
                originalScale.y * scaleMultiplier,
                originalScale.z
            );
            
            // Set parent after scaling to avoid any unwanted scale modifications
            newPos.transform.SetParent(this.transform);

            float xPos = (-boardWidth/2 + (i * slotSpacing)) / boardWidth;
            newPos.transform.localPosition = new Vector3(xPos, 0f, -1f);
    
            CardSlotsPos.Add(newPos, null);
            
        }

    }

    public GameObject CheckIfPlayed(GameObject card)
    {
        if (card == null)
        {
            return null; 
        }

        foreach(KeyValuePair<GameObject, CardHandler> entry in CardSlotsPos)
        {
            GameObject slot = entry.Key;   
            float distance = Vector2.Distance(card.transform.position, slot.transform.position);
            if(distance < minPlayDistance && entry.Value == null)
            {
                CardSlotsPos[slot] = card.GetComponent<CardHandler>(); 
                return slot;
            }
        }
        return null; 
    }
}
