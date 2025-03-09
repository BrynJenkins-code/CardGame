using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{

    protected CardHandler card;
    public bool isDone = false; 
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
    public abstract void OnDone(); 
    public abstract void OnBoardUpdate(CardHandler[] cards); 

     // Event handlers for broader game state changes
    protected virtual void OnTurnStarted() { }
    protected virtual void OnTurnEnded() { }
    protected virtual void OnBoardStateChanged(CardHandler[] newState) { }

    private void SubscribeToEvents()
    {
        GameEvents.OnBoardStateChanged += OnBoardUpdate;
    }

    private void UnsubscribeFromEvents()
    {
        GameEvents.OnBoardStateChanged -= OnBoardUpdate;
    }

}
