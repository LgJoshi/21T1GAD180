using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    //this are used to reference the "PlayerOptions" scripts located on the buttons.
    public PlayerOptions optionOne;
    public PlayerOptions optionTwo;
    public PlayerOptions optionThree;

    //this is the the list of PlayerOption scripts located on the buttons
    PlayerOptions[] optionsList;

    //these will be used to reference the User scripts maybe depending on what we decide to do.
    /*public UserA userA;
    public UserB userB;
    public UserC userC;
    */

    //these are the arrays which contain ALL the dialogue and tags we'll be using
    //eventually the dialogue will be expanded to include all the different categories of dialogue
    string[] dialogue;
    string[] tags;
    string[][] dialogueCategories;

    //the dialogue and tags will be copied from the above arrays to these lists which can then be manipulated
    List<string> dialogueList;
    List<string> tagsList;

    //these are the current dialogues and tags for the buttons themselves
    string[] currentDialogue;
    string[] currentTags;

    //runs when scene is loaded
    void Awake() {
        //defines optionsList as an array of the PlayerOptions scripts
        optionsList = new PlayerOptions[] { optionOne, optionTwo, optionThree };

        //sets placeholder text and tags. will be changed later.
        currentDialogue = new string[] { "Option1", "Option2", "Option3" };
        currentTags = new string[] { "tag1", "tag2", "tag3" };

        //These are the arrays which contain all the dialogue and tags
        dialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg"};
        tags = new string[] { "TagA", "TagB", "TagC", "TagD", "TagE", "TagF", "TagG" };

        //These are the lists which can be manipulated and changed for new dialogue and tags
        dialogueList = new List<string>(dialogue);
        tagsList = new List<string>(tags);

        //this "for loop" will activate the ChangeDialogue function on the PlayerOptions scripts on all three buttons.
        //it pulls from the current dialogue and current tags arrays
        //this is used multiple times in this script
        for( int i = 0;i < 3;i++ ) {
            optionsList[i].ChangeDialogue( currentDialogue[i], currentTags[i] );
        }
    }

    private void Update() {
        //debug button. press 1 to see current tags on buttons.
        if( Input.GetKeyDown("1") ) {
            print("Tag 1 is " + currentTags[0]);
            print("Tag 1 is " + currentTags[1]);
            print("Tag 1 is " + currentTags[2]);
        }
    }

    public void DialogueChosen(int buttonNumber) {
        /*
        MoodCheck(optionsList[buttonNumber].GetTag());
        */

        //debugger text
        print("button "+buttonNumber+" pressed");

        //this "for loop" pulls a random tag and dialogue from the lists and puts them in current dialogue/tag
        for( int i = 0;i < 3;i++ ) {
            int randomSelect = Random.Range(0, dialogueList.Count);
            currentDialogue[i] = dialogueList[randomSelect];
            currentTags[i] = tagsList[randomSelect];
        }

        //this function updates text and tag on buttons (see below)
        NewDialogue();
    }

    //Function used by users to compare tag
    public void MoodCheck(string chosenTag ) {

    }

    public void NewDialogue() {

        for( int i = 0;i < 3;i++ ) {
            optionsList[i].ChangeDialogue(currentDialogue[i], currentTags[i]);
        }
    }
}
