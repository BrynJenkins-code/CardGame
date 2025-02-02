using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBehaviour : MonoBehaviour
{

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
    public abstract void OnBoardUpdate(CardHandler[] cards); 

}
