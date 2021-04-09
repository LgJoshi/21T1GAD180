using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerOptions : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI myText;
    Button myButton;
    Image myImage;

    bool selected;
    string myTag;

    void OnEnable() {
        EventManager.EndEvent += DisableSelf;
        EventManager.OptionEvent += TempDisable;
    }
    void OnDisable() {
        EventManager.EndEvent -= DisableSelf;
        EventManager.OptionEvent -= TempDisable;
    }
    void Awake() {
        myText = GetComponentInChildren<TextMeshProUGUI>();
        myButton = GetComponent<Button>();
        myImage = GetComponent<Image>();

        selected = false;
    }

    public void ChangeDialogue(string newText, string newTag) {
        myText.text = newText;
        myTag = newTag;
    }

    public void ImSelected() {
        selected = true;
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

        yield return new WaitForSeconds(2);

        myButton.enabled = false;
        myImage.enabled = false;
        myText.enabled = false;

        //time before buttons reappear
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
