using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHandler : MonoBehaviour
{   
     public string cardName; 
    public string cardDesc; 
    public int manaCost; 
    public int rarity; 
    public Sprite image;
    public Renderer rend;

    //to be assigned when creating a deck.
    public int uid; 

    // It may be that these aren't strings, but rather classes. 
    public List<CardBehaviour> events;

    /// <summary>
    /// Input Handling
    /// </summary>
    private bool dragging = false;  
    private float distance;
    private Vector3 startDist; 
    private Vector3 startPos; 

    //Need to implement some way of this being set automatically. 
    public GameObject Board; 
    public GameObject enemy; 

    public Vector3 localScale;
    private bool played = false;  

    // Start is called before the first frame update
    void Awake()
    {
        events = new List<CardBehaviour>(GetComponents<CardBehaviour>());
    }

    void Update()
    {
        if (dragging)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(distance) + startDist;
            rayPoint.z = transform.position.z; 
            transform.position = rayPoint;
        }
    }

    // The mesh goes red when the mouse is over it...
    void OnMouseEnter()
    {
        this.transform.localScale = this.transform.localScale + new Vector3(0.05f, 0.25f, 0);
    }

    // ...and the mesh finally turns white when the mouse moves away.
    void OnMouseExit()
    {
        if(played)
        {
            this.transform.localScale = new Vector3(1,1,1); 
        }
        else
        {
            this.transform.localScale = localScale;
        }
    }

    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        startDist = transform.position - rayPoint;
        startPos = transform.position; 
    }

    void OnMouseUp()
    {
        dragging = false;
        CheckIfPlayed();
    }

    /// <summary>
    /// Would like it to snap into the card slot border if possible. Also would be good to highlight card slots when dragging. This is good enough for now. 
    /// </summary>
    private void CheckIfPlayed()
    {    
        GameObject slot = Board.GetComponent<BoardHandler>().CheckIfPlayed(gameObject); 
        if(slot != null)
        {
            transform.position = slot.transform.position;
            
            this.transform.SetParent(slot.transform, false);
            transform.localPosition = new Vector3(0, 0, -1f); 
            transform.localScale = new Vector3(1, 1, 1);
            PlayCard();
            played = true; 

        }
        else
        {
            transform.position = startPos;
        }
    }

    public void PlayCard()
    {
        foreach (CardBehaviour cardBehaviour in events)
        {
            cardBehaviour.OnPlay(); 
        }
    }
}
