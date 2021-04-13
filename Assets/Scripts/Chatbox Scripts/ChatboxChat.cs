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
        EventManager.OptionEvent += ChatTextScroll;
    }
    void OnDisable() {
        EventManager.OptionEvent -= ChatTextScroll;
    }

    void Awake() {

        //if this is changed, make sure it matches chatboxpic
        timeSpan = 4;

        chatDelay = timeSpan / 4;
        myImage = this.GetComponent<Image>();
        myText = GetComponentInChildren<TextMeshProUGUI>();
        gameMaster = GameObject.Find("Master").GetComponent<GameMaster>();

        positiveResponse = new string[] { "111111111111111", "22222222222222", "333333333333333", "44444444444" };
        //positiveResponse = new string[] { "That sounds good", "That sounds promising", "Oooooooo", "You've piqued my interest" };
        negativeResponse = new string[] { "Meh", "I dunno" };
        myText.text = " ";
        textHistory = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
        textSelect = historyNumber;

        activeUsers = 3;
        activeStates = new bool[3];
        responseStates = new bool[3];
        historySelect = 3;
    }

    // Update is called once per frame
    void Update() {
        if( Input.GetKeyDown("2") ) {
            textSelect = historyNumber;
            updateResponses();
            StartCoroutine(ScrollChat());
        }
        if( Input.GetKeyDown("3") ) {
            print(activeStates[0]);
        }
    }

    void ChatTextScroll() {
        updateResponses();
        StartCoroutine(ScrollChat());
    }

    void updateResponses() {
        activeStates = gameMaster.GetActiveStates();
        responseStates = gameMaster.GetResponseStates();
        textHistory[historySelect] = gameMaster.GetSelectedDialogue();
        IncrementHistorySelect();

        if( activeStates[0] ) {
            if( responseStates[0] ) {
                textHistory[historySelect] = positiveResponse[Random.Range(0,positiveResponse.Length)];
            } else {
                textHistory[historySelect] = negativeResponse[Random.Range(0, positiveResponse.Length)];
            }
            IncrementHistorySelect();
        }
        if( activeStates[1] ) {
            if( responseStates[1] ) {
                textHistory[historySelect] = positiveResponse[Random.Range(0, positiveResponse.Length)];
            } else {
                textHistory[historySelect] = negativeResponse[Random.Range(0, positiveResponse.Length)];
            }
            IncrementHistorySelect();
        }
        if( activeStates[2] ) {
            if( responseStates[2] ) {
                textHistory[historySelect] = positiveResponse[Random.Range(0, positiveResponse.Length)];
            } else {
                textHistory[historySelect] = negativeResponse[Random.Range(0, positiveResponse.Length)];
            }
            IncrementHistorySelect();
        }
    }

    void IncrementHistorySelect() {
        historySelect++;
        if( historySelect >= 8 ) {
            historySelect = 0;
        }
    }

    IEnumerator ScrollChat() {

        //if this is changed, make sure it matches chatboxpic and playeroptions
        yield return new WaitForSeconds(1.5f);

        if( historyNumber == 3 ) {
            myImage.enabled = true;
            myText.enabled = true;
        }

        int i = 0;
        while( i < activeUsers+1 ) {
            i++;
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
}
