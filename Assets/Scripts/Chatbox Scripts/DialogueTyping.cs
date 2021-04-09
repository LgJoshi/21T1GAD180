using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueTyping : MonoBehaviour
{
    public TextMeshProUGUI myText;
    public GameMaster gameMaster;
    string myDialogue;
    float typingDelay;

    public TextMeshProUGUI gameOneText;
    public TextMeshProUGUI gameTwoText;
    public TextMeshProUGUI gameThreeText;
    TextMeshProUGUI[] textArray;


    void OnEnable() {
        EventManager.StartEvent += StartPlayText;
        EventManager.OptionEvent += ChangeText;
    }
    void OnDisable() {
        EventManager.StartEvent -= StartPlayText;
        EventManager.OptionEvent -= ChangeText;
    }

    private void Awake() {
        textArray = new TextMeshProUGUI[] { gameOneText, gameTwoText, gameThreeText };
        this.GetComponent<Image>().enabled = false;
        myText.text = " ";
    }

    void StartPlayText() {
        this.GetComponent<Image>().enabled = true;
        myDialogue = "Who wants to play " + textArray[gameMaster.GetSelectedGame()].text + "?";
        typingDelay = 1.6f / myDialogue.Length;
        StartCoroutine(PlayText());
    }

    void ChangeText() {
        StopCoroutine(PlayText());
        myDialogue = gameMaster.GetSelectedDialogue();
        myText.text = " ";
        typingDelay = 1.6f / myDialogue.Length;
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText() {
        foreach (char c in myDialogue){
            myText.text += c;
            yield return new WaitForSeconds(typingDelay);
        }
    }
}
