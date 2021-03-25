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
    string[] actionDialogue;
    string[] adventureDialogue;
    string[] simulationDialogue;
    string[] sportsDialogue;
    string[] coopDialogue;
    string[] survivalDialogue;
    string[] fpsDialogue;
    string[] pvpDialogue;
    string[] sandboxDialogue;
    string[] craftingDialogue;
    string[] tacticalDialogue;

    //the dialogue and tags will be copied from the above arrays to these lists which can then be manipulated
    List<string> dialogueList;
    List<string> tagsList;
    List<string[]> categoriesList;

    //these are the current dialogues and tags for the buttons themselves
    string[] currentDialogue;
    string[] currentTags;

    //This is a getter for the tag that was selected
    public string selectedTag;
    public string GetSelectedTag() {
        return selectedTag;
    }

    //runs when scene is loaded
    void Awake() {
        //defines optionsList as an array of the PlayerOptions scripts
        optionsList = new PlayerOptions[] { optionOne, optionTwo, optionThree };

        //sets placeholder text and tags. will be changed later.
        currentDialogue = new string[] { " ", " ", " " };
        currentTags = new string[] { " ", " ", " " };

        //These are the arrays which contain all the dialogue and tags
        actionDialogue = new string[] { "Oh yeah action!", "I love action"};
        adventureDialogue = new string[] { "Adventure yeah yeah", "Let's go on a journey"};
        simulationDialogue = new string[] { "Simulation baby", "Fly planes yeah"};
        sportsDialogue = new string[] { "Kick a ball booyeah", "Sport yeahhhh", "Kick stuff sport yaay"};
        coopDialogue = new string[] { "Cooperate", "Do the coop", "I love coop" };
        survivalDialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg" };
        fpsDialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg" };
        pvpDialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg" };
        sandboxDialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg" };
        craftingDialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg" };
        tacticalDialogue = new string[] { "Aa", "Bb", "Cc", "Dd", "Ee", "Ff", "Gg" };

        tags = new string[] { "Action", "Adventure", "Simulation", "Sports", "Co-op", "Survival", 
                              "FPS", "PvP", "Sandbox", "Crafting", "Tactical" };
        dialogueCategories = new[] { actionDialogue, adventureDialogue, simulationDialogue, sportsDialogue, 
                                     coopDialogue, survivalDialogue, fpsDialogue, pvpDialogue, sandboxDialogue, 
                                     craftingDialogue, tacticalDialogue };

        //These are the lists which can be manipulated and changed for new dialogue and tags
        //dialogueList = new List<string>(dialogue);
        //I need to figure out a way to make tagsList & categoriesList only accept the relevant tags
        tagsList = new List<string> { tags[0], tags[1], tags[2], tags[3], tags[4] };
        categoriesList = new List<string[]> { dialogueCategories[0], dialogueCategories[1], dialogueCategories[2], dialogueCategories[3], dialogueCategories[4] };

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

    //function that runs when option is chosen
    public void DialogueChosen(int buttonNumber) {

        //takes the tag of the relevant button and updates selectedTag to match the tag of the button
        selectedTag = currentTags[buttonNumber];

        //Runs an event
        //EventManager.OptionsChosen();
        
        //debugger text
        print("button "+buttonNumber+" pressed");

        //this "for loop" pulls a random tag and dialogue from the lists and puts them in current dialogue/tag
        for( int i = 0;i < 3;i++ ) {
            int randomSelect = Random.Range(0, categoriesList.Count);
            List<string> randomTagList = new List<string> { tagsList[randomSelect] };
            currentTags[i] = randomTagList[Random.Range(0, randomTagList.Count)];
            List<string> randomDialogueList = new List<string> ( categoriesList[randomSelect] );
            currentDialogue[i] = randomDialogueList[Random.Range(0, randomDialogueList.Count)];
        }

        //this function updates text and tag on buttons (see below)
        NewDialogue();
    }

    //this function updates text and tag on buttons
    public void NewDialogue() {
        
        //goes through each PlayerOptions script and changes relevant dialogue and tag
        for( int i = 0;i < 3;i++ ) {
            optionsList[i].ChangeDialogue(currentDialogue[i], currentTags[i]);
        }
    }
}
