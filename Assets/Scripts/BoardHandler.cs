using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BoardHandler : MonoBehaviour
{

    private GameManager GameManager; 


    /// <summary>
    /// Variables for handling player interaction/information. 
    /// </summary>
    private int Health; 
    private Dictionary<string, CardHandler> Hand = new Dictionary<string, CardHandler>();

    /// <summary>
    /// Variables for handling card placements. 
    /// </summary>
    private List<Vector3> CardSlotsPos = new List<Vector3>();  
    public int CardSlots; 
    public GameObject prefab; 
    private MeshRenderer renderer; 

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

    private void SetupBoard()
    {
        renderer = gameObject.GetComponent<MeshRenderer>();
        float width = renderer.bounds.size.x; 
        float spacing = width / (float)CardSlots + 2; 
        float x = 0 - width/2; 
        for (int i = 0; i < CardSlots; i++)
        {   
            x = x + spacing; 
            CardSlotsPos.Add(new Vector3(x, 1f, 0f));
            GameObject.Instantiate(prefab, CardSlotsPos[i], Quaternion.identity, this.transform); 
            Debug.Log("Test Spawn " + CardSlotsPos[i].ToString());
        }

    }

    /// <summary>
    /// This method will be used to place a card on the board and check if it has any effects. 
    /// </summary>
    /// <param name="card"></param>
    public void PlayCard(CardHandler card)
    {

    }
    
    /// <summary>
    /// This method will be used to handle when a card is drawn. 
    /// </summary>
    /// <param name="card"></param>
    public void CardDrawn(CardHandler card)
    {

    }
}
