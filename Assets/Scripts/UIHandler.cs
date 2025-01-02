using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; 

public class UIHandler : MonoBehaviour
{
    private List<GameObject> HandSizePos = new List<GameObject>();  
    public int HandSize; 
    public GameObject prefab; 

    public GameObject PlayerBoard; 

    void Start()
    {
        SetupHand();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void SetupHand()
    {
        float boardWidth = 1f; 
        float spacing = boardWidth / ((float)HandSize + 2f); 
        float half = (HandSize +2f) /2f; 
        float x = 0f - (spacing * half);
        for (int i = 0; i < HandSize; i++)
        {   
            x = x + spacing; 
            GameObject newPos =  GameObject.Instantiate(prefab, new Vector3(0f, 0f, 0f), Quaternion.identity, this.transform); 
            // We are instantiating and then moving to asser the localPosition. This may not be optimal(TBD) 
            newPos.transform.localPosition = new Vector3(x, 0f, this.transform.position.z -1f); 
            newPos.transform.localScale= new Vector3(0.1f, 0.5f, 0.1f);
            newPos.GetComponent<CardHandler>().Board = PlayerBoard; 
            HandSizePos.Add(newPos);
        }
    }

    /// <summary>
    /// This method will be used to handle when a card is drawn. 
    /// </summary>
    /// <param name="card"></param>
    private void CardDrawn(GameObject card)
    {
        
    }



}