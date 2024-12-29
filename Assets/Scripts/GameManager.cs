using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState{
        PlayerDraw, 
        PlayerTurn,
        EnemyTurn,  
    }

    private GameObject EnemyBoard;
    private GameObject PlayerBoard; 


    private Dictionary<string, CardHandler> PlayerDeck = new Dictionary<string, CardHandler>();
    private Dictionary<string, CardHandler> EnemyDeck = new Dictionary<string, CardHandler>();


    // Start is called before the first frame update
    void Start()
    {
        SetupGame(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetupGame()
    {
        EnemyBoard = GameObject.FindGameObjectWithTag("EnemyBoard");
        PlayerBoard = GameObject.FindGameObjectWithTag("PlayerBoard");
    }

    /// <summary>
    ///  This method will be used for updating the state of the game. 
    /// </summary>
    public void UpdateGameState()
    {

    }
}
