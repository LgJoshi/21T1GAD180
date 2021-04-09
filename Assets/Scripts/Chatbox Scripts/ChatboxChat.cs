using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatboxChat : MonoBehaviour
{
    public int historyNumber;
    int textSelect;

    SpriteRenderer spriteRenderer;
    TextMeshProUGUI myText;

    string[] positiveResponse;
    string[] negativeResponse;
    string[] textHistory;

    /*
    int userASprite;
    int userBSprite;
    int userCSprite;
    */

    float timeSpan;
    float chatDelay;

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
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        myText = GetComponentInChildren<TextMeshProUGUI>();

        positiveResponse = new string[] { "111111111111111", "22222222222222", "333333333333333", "44444444444" };
        //positiveResponse = new string[] { "That sounds good", "That sounds promising", "Oooooooo", "You've piqued my interest" };
        negativeResponse = new string[] { "Meh", "I dunno" };
        myText.text = " ";
        textHistory = new string[] { " ", " ", " ", " " };
    }

    // Update is called once per frame
    void Update() {
        if( Input.GetKeyDown("2") ) {
            textSelect = historyNumber;
            StartCoroutine(ScrollChat());
        }
    }

    void ChatTextScroll() {
        textSelect = historyNumber;
        for( int i = 0;i < 4;i++ ) {
            textHistory[i] = positiveResponse[i];
        }
        
        StartCoroutine(ScrollChat());
    }

    IEnumerator ScrollChat() {

        //if this is changed, make sure it matches chatboxpic and playeroptions
        yield return new WaitForSeconds(2);

        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
            myText.enabled = true;
        }

        int i = 0;
        while( i < 4 ) {
            i++;
            myText.text = textHistory[textSelect];
            textSelect++;
            if( textSelect >= 4 ) {
                textSelect = 0;
            }
            yield return new WaitForSeconds(chatDelay);
        }
        textSelect++;
        if( textSelect >= 4 ) {
            textSelect = 0;
        }
        if( historyNumber == 3 ) {
            spriteRenderer.enabled = false;
            myText.enabled = false;
        }
    }
}
