using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjacentDealDamage : CardBehaviour
{
    public int damageAmount; 
    public int maxNumOfAttacks; 
    private int noOfAttacks; 
    CardHandler[] currentBoardState; 


    public override void OnPlay()
    {
    }

    public override void OnDiscard()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDraw()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDone()
    {
    }

    public override void OnBoardUpdate(CardHandler[] cards)
    {
        // Get this card's position in the array
        int pos = Array.IndexOf(cards, card);

        // If this is the first board update, initialize currentBoardState
        if (currentBoardState == null) {
            currentBoardState = cards;
            return;
        }

        // Skip if position not found
        if (pos == -1) {
            return;
        }
        // Check left adjacent if not at start
        if (pos > 0) {
            CardHandler leftCard = cards[pos - 1];
            if (leftCard != null && leftCard != currentBoardState[pos - 1]) {
                card.enemy.GetComponent<EnemyController>().health -= damageAmount;
                noOfAttacks++; 
            }
        }

        // Check right adjacent if not at end
        if (pos < cards.Length - 1) {
            CardHandler rightCard = cards[pos + 1];
            if (rightCard != null && rightCard != currentBoardState[pos + 1]) {
                card.enemy.GetComponent<EnemyController>().health -= damageAmount;
                noOfAttacks++; 
            }
        }
        if(noOfAttacks >= maxNumOfAttacks)
        {
            isDone = true; 
        }
        currentBoardState = cards; 
    }
    
}    
    