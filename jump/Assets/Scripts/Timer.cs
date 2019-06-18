using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {
    public float timer = 999;
    private Text timerText;

	void Start () {
        timerText = GetComponent<Text>();
	}
	
	void Update () {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f2"); //round timer to 2 decimal spaces
	}
}
