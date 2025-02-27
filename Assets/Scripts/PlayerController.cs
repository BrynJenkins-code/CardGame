using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 

public class PlayerController : MonoBehaviour
{
    public string deckName;
    public int health; 
    public List<CardHandler> cards; 
    private List<GameObject> HandSizePos = new List<GameObject>();  
    public int HandSize; 
    public GameObject prefab; 

    public GameObject PlayerBoard; 

    // This should be getting set from the game maanger. 
    public GameObject enemy; 


    // Start is called before the first frame update
    void Start()
    {
        SetupDeck(); 
        SetupHand(); 
        PlayerBoard = GameObject.FindGameObjectWithTag("PlayerBoard");  
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
        float handWidth = 0; 
        if (TryGetComponent<Renderer>(out Renderer renderer))
        {
            handWidth = renderer.bounds.size.x;
        }
        else
        {
            handWidth = 2f; // fallback value
        }
        Vector3 originalScale = prefab.transform.localScale;
                    // Preserve the original aspect ratio while scaling to the new width
            

        
        float cardWidth = handWidth / (HandSize * 1.2f);
        float cardSpacing = cardWidth *1.5f;
        float scaleMultiplier = cardWidth / originalScale.x;

        for (int i = 0; i < HandSize; i++)
        {   
            GameObject newPos = GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity); 
            
            newPos.transform.localScale = new Vector3(
                originalScale.x * scaleMultiplier,
                originalScale.y * scaleMultiplier,
                originalScale.z
            );
            
            // Set parent after scaling to avoid any unwanted scale modifications
            newPos.transform.SetParent(this.transform);

            float xPos = (-handWidth/2 + (i * cardSpacing)) / handWidth;
            newPos.transform.localPosition = new Vector3(xPos, 0f, -0.1f * i);
            
            newPos.GetComponent<CardHandler>().Board = PlayerBoard; 
            newPos.GetComponent<CardHandler>().enemy = enemy; 
            newPos.GetComponent<CardHandler>().localScale = newPos.transform.localScale; 

            HandSizePos.Add(newPos);
        }
    }
}
