using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 

public class DeckHandler : MonoBehaviour
{
    public string deckName;
    public List<CardHandler> cards; 

    // Start is called before the first frame update
    void Start()
    {
        SetupDeck(); 
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
}
