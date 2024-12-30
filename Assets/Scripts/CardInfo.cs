using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="card", menuName = "Create new card")]
public class CardInfo : ScriptableObject
{
    public string cardName; 
    public string cardDesc; 
    public int manaCost; 
    public int rarity; 
    public Sprite image;

    //to be assigned when creating a deck.
    public int uid; 

    // It may be that these aren't strings, but rather classes. 
    public List<CardBehaviour> events; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
