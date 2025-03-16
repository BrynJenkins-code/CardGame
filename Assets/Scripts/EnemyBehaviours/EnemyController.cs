using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;
    public TMP_Text healthText;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("player");
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + "";
    }
}
