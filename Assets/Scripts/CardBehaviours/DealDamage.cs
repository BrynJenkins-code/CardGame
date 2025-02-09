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
    }

    public override void OnDiscard()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDraw()
    {
        throw new System.NotImplementedException();
    }

    public override void OnDie()
    {
        throw new System.NotImplementedException();
    }

    public override void OnBoardUpdate(CardHandler[] cards)
    {
        throw new System.NotImplementedException();
    }
}
