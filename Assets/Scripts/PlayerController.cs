using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private string deckName;  // Only public if needed by other scripts

    private Dictionary<GameObject, int> cards = new Dictionary<GameObject, int>();

    private List<GameObject> hand = new List<GameObject>();
    [SerializeField] private int handSize;
    [SerializeField] private GameObject deckPos;
    [SerializeField] private GameObject cardPrefab;  // Renamed for clarity
    [SerializeField] private GameObject playerBoard;
    [SerializeField] private GameObject enemy;  // Keep public if game manager needs to set it
    // Player Stats. 
    [SerializeField] public int health;


    public int shield;

    // Misc Variables
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        SetupDeck();
        playerBoard = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// PUBLIC METHODS. 
    /// </summary>
    /// 
    public void DrawCard()
    {
        if (hand.Count >= handSize)
        {
            return;
        }
        GameObject card = SelectCard();
        if (card != null)
        {
            hand.Add(card);
            RenderHand();
        }
    }

    /// <summary>
    /// Removing a card from the hand. 
    /// </summary>
    /// <param name="card"></param>
    public void RemoveCardFromHand(GameObject card)
    {
        if (card != null)
        {
            hand.Remove(card);
            RenderHand();
        }
    }

    /// <summary>
    /// Add a new card to the deck.  
    /// </summary>
    /// <param name="card"> CardHandler Object to add. </param>
    private void AddCardToDeck(GameObject card)
    {
        if (cards.ContainsKey(card))
        {
            cards[card]++;
        }
        else
        {
            cards.Add(card, 1);
        }
    }

    /// <summary>
    /// Remove a card from the deck. 
    /// </summary>
    /// <param name="card"> CardHandler Object to remove. </param>
    private void RemoveCardFromDeck(GameObject card)
    {
        if (cards.ContainsKey(card))
        {
            cards[card]--;
            if (cards[card] <= 0)
            {
                cards.Remove(card);
            }
        }
    }


    /// <summary>
    /// PRIVATE METHODS. 
    /// </summary>
    /// 
    private void SetupDeck()
    {
        List<GameObject> deck = this.GetComponent<DeckHandler>().deck;
        foreach (GameObject card in deck)
        {
            // This bit is still a bit hard coded. Make a proper deck slot (So we can also hide the top card. )
            GameObject newCard = GameObject.Instantiate(card, deckPos.transform.position, Quaternion.identity);
            newCard.GetComponent<CardHandler>().Board = playerBoard;
            newCard.GetComponent<CardHandler>().enemy = enemy;

            AddCardToDeck(newCard);
        }

        for (int i = 0; i < handSize; i++)
        {
            DrawCard();
        }
    }

    private void RenderHand()
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
        Vector3 originalScale = cardPrefab.transform.localScale;
        // Preserve the original aspect ratio while scaling to the new width        
        float cardWidth = handWidth / (handSize * 1.2f);
        float cardSpacing = cardWidth * 1.5f;
        float scaleMultiplier = cardWidth / originalScale.x;
        int i = 0;

        foreach (GameObject currentCard in hand)
        {
            // /This bit stopped working for some reason. Maybe fix?
            currentCard.transform.localScale = new Vector3(
                originalScale.x * scaleMultiplier,
                originalScale.y * scaleMultiplier,
                originalScale.z
            );

            float xPos = ((-handWidth / 2 + (i * cardSpacing)) / handWidth) * this.transform.localScale.x;
            currentCard.transform.DOMove(new Vector3(xPos, this.transform.position.y, (-0.1f * i) - 2f), 0.6f);
            currentCard.GetComponent<CardHandler>().localScale = currentCard.transform.localScale;
            i++;
        }
    }

    /// <summary>
    /// Draw a random card from the deck. 
    /// </summary>
    /// <returns>Returns a card handler object of the selected card. </returns>
    private GameObject SelectCard()
    {
        if (cards.Count == 0)
        {
            return null;
        }

        // Convert dictionary keys to list for random selection
        List<GameObject> cardList = new List<GameObject>(cards.Keys);

        // Get random index
        int randomIndex = Random.Range(0, cardList.Count);

        // Get the randomly selected card
        GameObject selectedCard = cardList[randomIndex];

        RemoveCardFromDeck(selectedCard);
        return selectedCard;
    }
}
