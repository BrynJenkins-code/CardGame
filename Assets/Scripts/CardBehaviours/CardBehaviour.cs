using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{

    protected CardHandler card;
    protected virtual void Awake()
    {
        card = GetComponent<CardHandler>();
        SubscribeToEvents();
    }

    protected virtual void OnDestroy()
    {
        UnsubscribeFromEvents();
    }

    public abstract void OnPlay();
    public abstract void OnDiscard(); 
    public abstract void OnDraw(); 
    public abstract void OnDie(); 
    public abstract void OnBoardUpdate(CardHandler[] cards); 

     // Event handlers for broader game state changes
    protected virtual void OnTurnStarted() { }
    protected virtual void OnTurnEnded() { }
    protected virtual void OnBoardStateChanged(CardHandler[] newState) { }

    private void SubscribeToEvents()
    {
        GameEvents.OnTurnStarted += OnTurnStarted;
        GameEvents.OnTurnEnded += OnTurnEnded;
        GameEvents.OnBoardStateChanged += OnBoardStateChanged;
    }

    private void UnsubscribeFromEvents()
    {
        GameEvents.OnTurnStarted -= OnTurnStarted;
        GameEvents.OnTurnEnded -= OnTurnEnded;
        GameEvents.OnBoardStateChanged -= OnBoardStateChanged;
    }

}
