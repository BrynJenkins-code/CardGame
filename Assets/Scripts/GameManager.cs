using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum GameState
    {
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
    public TMP_Text healthText;


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
        healthText.text = player.transform.GetComponent<PlayerController>().health.ToString();
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
