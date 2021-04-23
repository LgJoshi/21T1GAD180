using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatboxChat : MonoBehaviour
{
    public int historyNumber;
    int textSelect;

    Image myImage;
    TextMeshProUGUI myText;
    GameMaster gameMaster;

    string[] positiveResponse;
    string[] negativeResponse;
    string[] textHistory;

	AudioSource audioSource;
	public AudioClip BubblePop;

    float timeSpan;
    float chatDelay;

    int historySelect;
    int activeUsers;
    bool[] activeStates;
    bool[] responseStates;

    bool aActive;
    bool bActive;
    bool cActive;

    bool aPositive;
    bool bPositive;
    bool cPositive;

    void OnEnable() {
        EventManager.StartEvent += StartupChat;
        EventManager.ChatScrollEvent += ChatTextScroll;
        EventManager.EndEvent += StopGame;
    }
    void OnDisable() {
        EventManager.StartEvent -= StartupChat;
        EventManager.ChatScrollEvent -= ChatTextScroll;
        EventManager.EndEvent -= StopGame;
    }

    void Start()
	{
		audioSource = this.GetComponent<AudioSource>();
        gameMaster = GameObject.Find("Master").GetComponent<GameMaster>();
    }

    void Awake() {

        //if this is changed, make sure it matches chatboxpic
        timeSpan = 4;

        chatDelay = timeSpan / 4;
        myImage = this.GetComponent<Image>();
        myText = GetComponentInChildren<TextMeshProUGUI>();

        myImage.enabled = false;
        myText.enabled = false;
        myText.text = " ";
        textHistory = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
        textSelect = historyNumber;

        historySelect = 3;

        activeUsers = 3;
    }

    // Update is called once per frame
    void Update() {
        if( Input.GetKeyDown("2") ) {
            textSelect = historyNumber;
            textHistory = gameMaster.GetTextHistory();
            StartCoroutine(ScrollChat());
        }
        if( Input.GetKeyDown("3") ) {
            print(activeStates[0]);
        }
    }

    void StartupChat() {
        textHistory = gameMaster.GetTextHistory();
        StartCoroutine(StartupScroll());
    }

    IEnumerator StartupScroll() {
        yield return new WaitForSeconds(1.5f);
        if( historyNumber == 3 ) {
            myImage.enabled = true;
            myText.enabled = true;
            myText.text = textHistory[1];
            yield return new WaitForSeconds(chatDelay);
            myImage.enabled = false;
            myText.enabled = false;
        }
        if( historyNumber == 2 ) {
            yield return new WaitForSeconds(chatDelay);
            myImage.enabled = true;
            myText.enabled = true;
            myText.text = textHistory[1];
        }
    }

    void ChatTextScroll() {
        textHistory = gameMaster.GetTextHistory();
        activeUsers = gameMaster.GetActiveUsers();
        StartCoroutine(ScrollChat());
    }

    IEnumerator ScrollChat() {

        //if this is changed, make sure it matches chatboxpic and playeroptions
        yield return new WaitForSeconds(1.5f);

        if( historyNumber == 3 ) {
            myImage.enabled = true;
            myText.enabled = true;
            if( textSelect == 0 ) {
                myText.text = textHistory[7];
            } else {
                myText.text = textHistory[textSelect - 1];
            }
        }
        
        yield return new WaitForSeconds(chatDelay);

        int i = 0;
        while( i < activeUsers ) {
            if( historyNumber == 3 ) {
                audioSource.PlayOneShot(BubblePop, 0.3f);
            }
            i++;
            //enables chatbox dialogue boxes starting from the first message
            if( textSelect == 1 ) {
                myImage.enabled = true;
                myText.enabled = true;
            }
            
            myText.text = textHistory[textSelect];
            textSelect++;
            if( textSelect >= 8 ) {
                textSelect = 0;
            }
            yield return new WaitForSeconds(chatDelay);
        }
        myText.text = textHistory[textSelect];
        textSelect++;
        if( textSelect >= 8 ) {
            textSelect = 0;
        }
        if( historyNumber == 3 ) {
            myImage.enabled = false;
            myText.enabled = false;
        }
    }

    void StopGame() {
        StopAllCoroutines();
    }
}
