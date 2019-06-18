using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    public float ftimer;
    public float finalTime = 999;
    public float BestTime = 999;
    public Text scoreText;

    private Player player;
    private Timer t;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        t = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
    }

    void Update()
    {
        if (finalTime <= BestTime)
        {
            BestTime = finalTime;
            scoreText.text = BestTime.ToString("f2"); //round timer to 2 decimal spaces
        }
        else
        {
            scoreText.text = BestTime.ToString("f2"); //round timer to 2 decimal spaces
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            finalTime = 999f - t.timer;
        }
    }
}