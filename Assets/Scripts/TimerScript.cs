using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerScript : MonoBehaviour
{
    bool gameRunning;
    public float timer;

    public TextMeshProUGUI myText;
    string timerSeconds;

    void Start() {
        gameRunning = false;
    }

    //starts timer when a game is chosen
    void OnEnable() {
        EventManager.StartEvent += TimerStart;
    }
    void OnDisable() {
        EventManager.StartEvent -= TimerStart;
    }
    void TimerStart() {
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( gameRunning ) {
            timer -= Time.deltaTime;
            if( timer <= 0 ) {
                gameRunning = false;
                EventManager.GameEnded();
                myText.text = string.Format("{0:00}", timer);
            }
            myText.text = string.Format("{0:00.00}", timer);
        }
    }

    
}
