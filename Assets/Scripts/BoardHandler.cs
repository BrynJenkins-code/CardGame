using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BoardHandler : MonoBehaviour
{

    private GameManager GameManager; 
    public int HitPoints; 

    /// <summary>
    /// Variables for handling player interaction/information. 
    /// </summary>
    private int Health; 
    private Dictionary<string, CardHandler> Hand = new Dictionary<string, CardHandler>();

    /// <summary>
    /// Variables for handling card placements. 
    /// </summary>
    private List<GameObject> CardSlotsPos = new List<GameObject>();  
    public int CardSlots; 
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
    /// Good enough for now, this will become a problem if the number of card slots is too big, will need to make it account for scaling card slots down. 
    /// </summary>
    private void SetupBoard()
    {
        float boardWidth = 1f; 
        float spacing = boardWidth / ((float)CardSlots + 2f); 
        float half = (CardSlots +2f) /2f; 
        float x = 0f - (spacing * half);
        for (int i = 0; i < CardSlots; i++)
        {   
            x = x + spacing; 
            GameObject newPos =  GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, this.transform); 
            // We are instantiating and then moving to asser the localPosition. This may not be optimal(TBD) 
            newPos.transform.localPosition = new Vector3(x, 0f, this.transform.position.z -1f); 
            newPos.transform.localScale= new Vector3(0.1f, 0.3f, 0.1f);
            CardSlotsPos.Add(newPos);
        }

    }

    public bool CheckIfPlayed(GameObject card)
    {
        if (card == null)
        {
            return false; 
        }
        foreach (GameObject slot in CardSlotsPos)
        {
            float distance = Vector2.Distance(card.transform.position, slot.transform.position);
            
            if(distance < 60f)
            {
                Debug.Log(distance); 
                return true;
            }
        }

        return false; 
    }

    /// <summary>
    /// This method will be used to place a card on the board and check if it has any effects. 
    /// </summary>
    /// <param name="card"></param>
    public void PlayCard(CardHandler card, int position)
    {

    }
    

}
