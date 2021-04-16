using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerOptions : MonoBehaviour
{
    TextMeshProUGUI myText;
    Button myButton;
    Image myImage;
	AudioSource audioSource;
	public AudioClip Clicky;
    bool selected;
    string myTag;

    void Start()
	{
		audioSource = this.GetComponent<AudioSource>();
	}

    void OnEnable() {
        EventManager.StartEvent += StartupChat;
        EventManager.EndEvent += DisableSelf;
        EventManager.OptionEvent += TempDisable;
    }
    void OnDisable() {
        EventManager.StartEvent -= StartupChat;
        EventManager.EndEvent -= DisableSelf;
        EventManager.OptionEvent -= TempDisable;
    }
    void Awake() {
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myButton = GetComponent<Button>();
        myImage = GetComponent<Image>();

        selected = false;

        myButton.enabled = false;
        myImage.enabled = false;
        myText.enabled = false;
    }

    void StartupChat() {
        StartCoroutine(StartGameDelay());
    }

    IEnumerator StartGameDelay() {
        yield return new WaitForSeconds(2.5f);
        myButton.enabled = true;
        myImage.enabled = true;
        myText.enabled = true;
    }

    public void ChangeDialogue(string newText, string newTag) {
        myText.text = newText;
        myTag = newTag;
    }

    public void ImSelected() {
        selected = true;
		audioSource.PlayOneShot(Clicky,0.7f);
    }

    void TempDisable() {
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText() {
        if( !selected ) {
            myImage.enabled = false;
            myText.enabled = false;
        }
        myButton.enabled = false;
        
        //if this is changed, make sure it matches chatboxchat and chatboxpic
        yield return new WaitForSeconds(1.5f);

        myButton.enabled = false;
        myImage.enabled = false;
        myText.enabled = false;

        //time before buttons reappear. this time period should also equal total chatDelay (or timespan) in chatboxchat and chatboxpic
        yield return new WaitForSeconds(4);

        myButton.enabled = true;
        myImage.enabled = true;
        myText.enabled = true;
        selected = false;
    }

    public void DisableSelf() {
        gameObject.SetActive(false);
    }
}
