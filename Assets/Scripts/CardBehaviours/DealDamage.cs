using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : CardBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public override void OnPlay()
    {
        card.enemy.GetComponent<EnemyController>().health -= 10;
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
