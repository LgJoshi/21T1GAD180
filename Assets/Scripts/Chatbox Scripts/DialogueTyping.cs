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
	
	void Start()
	{
		audioSource = this.GetComponent<AudioSource>();
	}

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

        //if this is changed, make sure it matches initial delay during scroll and playtext couroutines on ChetboxChat, ChatboxPic and PlayerOptions
        intialTimespan = 1.4f;
    }

    void StartPlayText() {
        this.GetComponent<Image>().enabled = true;
        myDialogue = "Who wants to play " + textArray[gameMaster.GetSelectedGame()].text + "?";
        typingDelay = intialTimespan / myDialogue.Length;
        StartCoroutine(PlayText());
    }

    void ChangeText() {
		
        StopCoroutine(PlayText());
        myDialogue = gameMaster.GetSelectedDialogue();
        myText.text = " ";
        typingDelay = intialTimespan / myDialogue.Length;
		audioSource.PlayOneShot(TypingSounds,0.7f);
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText() {
        foreach (char c in myDialogue){
            myText.text += c;
            yield return new WaitForSeconds(typingDelay);
        }
    }
}
