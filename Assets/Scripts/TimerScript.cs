using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    bool gameRunning;
    bool spedUp;
    public float timer;
    public bool win = false;

    public TextMeshProUGUI myText;
    string timerSeconds;

    void Start() {
        gameRunning = false;
        spedUp = false;
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
        if( Input.GetKeyDown(0) ) {
            timer -= 15f;
        }
        if( gameRunning ) {
            timer -= Time.deltaTime;
            myText.text = string.Format("{0:00.00}", timer);
            if( timer <= 0 ) {
                gameRunning = false;
                EventManager.GameEnded();
                myText.text = "0";                
            }
        }

        if ( timer < 15f && spedUp==false) {
            EventManager.TimerSpeedup();
            spedUp = true;
        }

        /*if (gameRunning == false && win == true)
        {
            win = false;
            StartCoroutine(LoseSequence());
        }

        IEnumerator LoseSequence() {
            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene(sceneBuildIndex: 2);
        }
        else if (gameRunning == false && win == false)
        {
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }*/

    }


}
