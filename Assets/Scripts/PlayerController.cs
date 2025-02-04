using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 

public class PlayerController : MonoBehaviour
{
    public string deckName;
    public List<CardHandler> cards; 
    private List<GameObject> HandSizePos = new List<GameObject>();  
    public int HandSize; 
    public GameObject prefab; 

    public GameObject PlayerBoard; 


    // Start is called before the first frame update
    void Start()
    {
        SetupDeck(); 
        SetupHand();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupDeck()
    {
        /*
            Add something to read the deck from memory. 
        */
    }

    /// <summary>
    /// Draw a random card from the deck. 
    /// </summary>
    /// <returns>Returns a card handler object of the selected card. </returns>
    public CardHandler DrawCard()
    {
        int randomVal = Random.Range(0, cards.Count);
        return cards[randomVal]; 
    }

    /// <summary>
    /// Add a new card to the deck.  
    /// </summary>
    /// <param name="card"> CardHandler Object to add. </param>
    public void AddCard(CardHandler card)
    {
        card.uid = cards.Count; 
        cards.Add(card); 
    }

    /// <summary>
    /// Remove a card from the deck. 
    /// </summary>
    /// <param name="uid"> UID of the card to remove. </param>
    public void RemoveCard(int uid)
    {
        if(cards.Find(x => x.uid == uid) != null)
        {
            cards.Remove(cards.Find(x => x.uid == uid));
        }
    }
    private void SetupHand()
    {
        float boardWidth = 1f; 
        float spacing = boardWidth / ((float)HandSize + 2f); 
        float half = (HandSize +2f) /2f; 
        float x = 0f - (spacing * half);
        for (int i = 0; i < HandSize; i++)
        {   
            x = x + spacing; 
            GameObject newPos =  GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, this.transform); 
            // We are instantiating and then moving to asser the localPosition. This may not be optimal(TBD) 
            newPos.transform.localPosition = new Vector3(x, 0f, this.transform.position.z -1f); 
            newPos.transform.localScale= new Vector3(0.1f, 0.5f, 0.1f);
            newPos.GetComponent<CardHandler>().Board = PlayerBoard; 
            HandSizePos.Add(newPos);
        }
    }

    /// <summary>
    /// This method will be used to handle when a card is drawn. 
    /// </summary>
    /// <param name="card"></param>
    private void CardDrawn(GameObject card)
    {
        
    }
}
