using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerOptions : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI myText;



    public void ChangeDialogue(string newText, string tag) {
        myText.text = newText;
    }
}
