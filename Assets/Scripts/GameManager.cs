using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum GameState{
        PlayerDraw, 
        PlayerTurn,
        EnemyTurn,  
    }

    private GameObject EnemyBoard;
    private GameObject player; 
    private Dictionary<string, CardHandler> PlayerDeck = new Dictionary<string, CardHandler>();
    private Dictionary<string, CardHandler> EnemyDeck = new Dictionary<string, CardHandler>();

    public float drawTimer; 
    private float timeRemaining; 
    public Slider countdownBar;


    // Start is called before the first frame update
    void Start()
    {
        SetupGame(); 
        countdownBar.maxValue = drawTimer; 
        timeRemaining = drawTimer; 
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer(); 
    }

    private void SetupGame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    ///  This method will be used for updating the state of the game. 
    /// </summary>
    public void UpdateGameState()
    {

    }
    
    private void UpdateTimer()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining > 0)
        {
            countdownBar.value = timeRemaining; 
        }
        else
        {
            player.GetComponent<PlayerController>().DrawCard(); 
            timeRemaining = drawTimer; 
        }
     
    }

}
