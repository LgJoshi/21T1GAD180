using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public PlayerOptions optionOne;
    public PlayerOptions optionTwo;
    public PlayerOptions optionThree;

    /*public UserA userA;
    public UserB userB;
    public UserC userC;
    */

    string[] currentDialogue;
    string[] currentTags;
    PlayerOptions[] optionsList;

    string[] dialogue;
    string[] tags;

    List<string> dialogueList;
    List<string> tagsList;

    void Awake() {
        optionsList = new PlayerOptions[] { optionOne, optionTwo, optionThree };

        currentDialogue = new string[] { "Option1", "Option2", "Option3" };
        currentTags = new string[] { "tag1", "tag2", "tag3" };

        //These are the arrays which contain all the dialogue and tags
        dialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg"};
        tags = new string[] { "TagA", "TagB", "TagC", "TagD", "TagE", "TagF", "TagG" };

        //These are the lists which can be manipulated and changed for new dialogue and tags
        dialogueList = new List<string>(dialogue);
        tagsList = new List<string>(tags);

        print(Random.Range(0, dialogueList.Count));
        print(dialogueList[Random.Range(0, dialogueList.Count)]);

        for( int i = 0;i < 3;i++ ) {
            optionsList[i].ChangeDialogue( currentDialogue[i], currentTags[i] );
        }
    }

    private void Update() {
        if( Input.GetKeyDown("1") ) {
            print("Tag 1 is " + currentTags[0]);
            print("Tag 1 is " + currentTags[1]);
            print("Tag 1 is " + currentTags[2]);
        }
    }

    public void DialogueChosen(int buttonNumber) {

        //MoodCheck(optionsList[buttonNumber].GetTag());
        print("button "+buttonNumber+" pressed");
        NewDialogue();
        

        for( int i = 0;i < 3;i++ ) {
            int randomSelect = Random.Range(0, dialogueList.Count);
            currentDialogue[i] = dialogueList[randomSelect];
            currentTags[i] = tagsList[randomSelect];
            print(i);
        }

        print(currentDialogue[1]);


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
