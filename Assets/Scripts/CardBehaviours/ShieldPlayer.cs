using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPlayer : CardBehaviour
{
    public int shieldAmount; 

    public override void OnPlay()
    {
        card.player.GetComponent<PlayerController>().shield += shieldAmount; 
        isDone = true; 
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
    }
    
}    
    