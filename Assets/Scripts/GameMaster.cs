using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
    // Start is called before the first frame update
    public PlayerOptions optionOne;
    public PlayerOptions optionTwo;
    public PlayerOptions optionThree;

    public UserA userA;
    public UserB userB;
    public UserC userC;

    string[] currentTags = new string[] { "tag1", "tag2", "tag3" };
    string[] currentDialogue = new string[] { "Option1", "Option2", "Option3" };
    PlayerOptions[] optionsList = new PlayerOptions[] { optionOne, optionTwo, optionThree };

    public void DialogueChosen(int buttonNumber) {
        
        MoodCheck(optionsList[buttonNumber].GetTag());
        
        optionOne.ChangeDialogue("hello", "banana");
    }

    public void MoodCheck(string chosenTag ) {

    }

    public void NewDialogue() {
        for(int i = 0; i < 3; i ++ ) {

        }
    }
}
