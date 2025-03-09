using UnityEngine;
using System.Collections.Generic;
public class DeckHandler : MonoBehaviour
{
    public string deckName; 
    public List<GameObject> deck = new List<GameObject>();     

    public void AddCard(GameObject card)
    {
        deck.Add(card);
    }

    /// <summary>
    /// Remove a card from the deck. 
    /// </summary>
    /// <param name="card"> CardHandler Object to remove. </param>
    public void RemoveCard(GameObject card)
    {
        deck.Remove(card);
    }
}
