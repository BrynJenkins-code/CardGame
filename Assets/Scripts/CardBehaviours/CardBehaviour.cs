using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{
    public string BehaviourUid; 
    enum onPlayType
    {
        None, 
        CheckAdjecent, 
        CheckBoard,
        CheckHand, 
        CheckPlayed
    }
    public OnPlayType onPlayType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void OnPlay();
    public abstract void OnDiscard(); 
    public abstract void OnDraw(); 
    public abstract void OnDie(); 

}
