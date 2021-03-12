using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI myText;

    string myTag;

    public string GetTag() {
        return myTag;
    }

    public void ChangeDialogue(string newText, string newTag) {
        myText.text = newText;
        myTag = newTag;
    }
}
