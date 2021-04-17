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
	AudioSource audioSource;
	public AudioClip TypingSounds;

    public TextMeshProUGUI gameOneText;
    public TextMeshProUGUI gameTwoText;
    public TextMeshProUGUI gameThreeText;
    TextMeshProUGUI[] textArray;

    float intialTimespan;
    float sendDelay;

    void Start()
	{
		audioSource = this.GetComponent<AudioSource>();
	}

    void OnEnable() {
        EventManager.StartEvent += StartPlayText;
        EventManager.OptionEvent += ChangeText;
        EventManager.EndEvent += StopGame;
    }
    void OnDisable() {
        EventManager.StartEvent -= StartPlayText;
        EventManager.OptionEvent -= ChangeText;
        EventManager.EndEvent -= StopGame;
    }

    private void Awake() {
        textArray = new TextMeshProUGUI[] { gameOneText, gameTwoText, gameThreeText };
        this.GetComponent<Image>().enabled = false;
        myText.text = " ";

        //if this is changed, make sure initialTimespan+sendDelay matches initial delay during scroll and playtext couroutines on ChetboxChat, ChatboxPic and PlayerOptions
        intialTimespan = .8f;
        sendDelay = 0.4f;
    }

    void StartPlayText() {
        this.GetComponent<Image>().enabled = true;
        myDialogue = "I'm looking for people to play " + textArray[gameMaster.GetSelectedGame()].text + "!";
        typingDelay = intialTimespan / myDialogue.Length;
        StartCoroutine(PlayText());
		audioSource.PlayOneShot(TypingSounds,0.7f);
    }

    void ChangeText() {
        StopCoroutine(PlayText());
        myDialogue = gameMaster.GetSelectedDialogue();
        typingDelay = intialTimespan / myDialogue.Length;
		StartCoroutine(PlayText());
		audioSource.PlayOneShot(TypingSounds,0.7f);
    }

    IEnumerator PlayText() {
        myText.text = " ";
        foreach (char c in myDialogue){
            myText.text += c;
            yield return new WaitForSeconds(typingDelay);
        }
        //delay before "sending" message
        yield return new WaitForSeconds(sendDelay);
        myText.text = " ";
    }

    void StopGame() {
        StopAllCoroutines();
    }
}
