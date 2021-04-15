using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    bool gameRunning;
    public float timer;
    public bool win = false;

    public TextMeshProUGUI myText;
    string timerSeconds;

    void Start() {
        gameRunning = false;
    }

    void Awake() {
        this.GetComponent<Image>().enabled = false;
        myText.text = " ";
    }

    //starts timer when a game is chosen
    void OnEnable() {
        EventManager.StartEvent += TimerStart;
    }
    void OnDisable() {
        EventManager.StartEvent -= TimerStart;
    }
    void TimerStart() {
        this.GetComponent<Image>().enabled = true;
        StartCoroutine(StartDelay());
    }

    IEnumerator StartDelay() {
        //this time must be consistent between PlayerOptions, TimerScript, ChatboxChat/4 and ChatboxPic/4
        yield return new WaitForSeconds(2.5f);
        gameRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( gameRunning ) {
            timer -= Time.deltaTime;
            myText.text = string.Format("{0:00.00}", timer);
            if( timer <= 0 ) {
                gameRunning = false;
                EventManager.GameEnded();
                myText.text = "0";
            }
        }

        if(gameRunning == false && win == true)
        {
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
        
    }

    
}
