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

    //This is a getter for the tag and dialogue that was selected
    public string selectedTag;
    public string GetSelectedTag() {
        return selectedTag;
    }
    public string selectedDialogue;
    public string GetSelectedDialogue() {
        return selectedDialogue;
    }

    //runs when scene is loaded
    void Awake() {
        //defines optionsList as an array of the PlayerOptions scripts
        optionsList = new PlayerOptions[] { optionOne, optionTwo, optionThree };

        //sets placeholder text and tags. will be changed later.
        currentDialogue = new string[] { " ", " ", " " };
        currentTags = new string[] { " ", " ", " " };

        //These are the arrays which contain all the dialogue and tags
        actionDialogue = new string[] { "This game really gets the blood pumping!", "Let's play something fast paced.", "How about some high octance gaming?"};
        adventureDialogue = new string[] { "We need to explore that new area we found.", "I heard about this new thing we can do.", "Let's see what the twist the story takes next."};
        simulationDialogue = new string[] { "It has some pretty realistic controls.", "The weather effects look really good!", "The physics are super realistic."};
        sportsDialogue = new string[] { "It's just like playing in real life!", "It has a pretty good announcer."};
        coopDialogue = new string[] { "I need my partner to watch my back!", "It's always better to play with friends.", "Let's see how far we can get this time." };
        survivalDialogue = new string[] { "Let's see how long we can survive.", "It's easier to survive with more people.", "Strength in numbers, come one!"};
        fpsDialogue = new string[] { "The best games are in first person.", "Let's try some of the unreal weaponry.", "I hear this game is pretty intense."};
        pvpDialogue = new string[] { "Come and take me on!", "We can team up against other players.", "Let's try and level our characters up."};
        sandboxDialogue = new string[] { "It's fun to mess around a bit.", "The possibilities are endless!", "We can do whatever we want."};
        craftingDialogue = new string[] { "There's lots of crafting options to unlock!", "I've collected a lot of materials for crafting.", "I found some new things to craft with!" };
        tacticalDialogue = new string[] { "Let's try this new strategy.", "I reckon we can figure out that section.", "We can practice that tactic we learned." };

        tags = new string[] { "Action", "Adventure", "Simulation", "Sports", "Co-Op", "Survival", 
                              "FPS", "PvP", "Sandbox", "Crafting", "Tactical" };
        dialogueCategories = new[] { actionDialogue, adventureDialogue, simulationDialogue, sportsDialogue, 
                                     coopDialogue, survivalDialogue, fpsDialogue, pvpDialogue, sandboxDialogue, 
                                     craftingDialogue, tacticalDialogue };
    }

    private void Update() {
        //debug button. press 1 to see current tags on buttons.
        if( Input.GetKeyDown("1") ) {
            print("Tag 1 is " + currentTags[0]);
            print("Tag 2 is " + currentTags[1]);
            print("Tag 3 is " + currentTags[2]);
        }
    }
    //int tagOne, int tagTwo, int tagThree, int tagFour, int tagFive
    public void GameSetup( string tagInput ) {
        string[] values = tagInput.Split(',');
        int[] convertedValues = System.Array.ConvertAll<string, int>(values, int.Parse);

        //These are the lists which can be manipulated and changed for new dialogue and tags
        tagsList = new List<string> { tags[convertedValues[0]], tags[convertedValues[1]], tags[convertedValues[2]], tags[convertedValues[3]], tags[convertedValues[4]] };
        categoriesList = new List<string[]> { dialogueCategories[convertedValues[0]], dialogueCategories[convertedValues[1]], dialogueCategories[convertedValues[2]], dialogueCategories[convertedValues[3]], dialogueCategories[convertedValues[4]] };

        NewDialogue();
        UpdateDialogue();
        EventManager.GameStarted();
    }

    //function that runs when option is chosen
    public void DialogueChosen(int buttonNumber) {

        //takes the tag of the relevant button and updates selectedTag to match the tag of the button
        selectedTag = currentTags[buttonNumber];
        selectedDialogue = currentDialogue[buttonNumber];

        //Runs an event
        EventManager.OptionsChosen();
        
        //debugger text
        print("button "+(buttonNumber+1)+" pressed");

        NewDialogue();
        UpdateDialogue();
    }

    //This function randomly selects from the list of available dialogue and updates currentTags and currentDialogue to match it
    void NewDialogue() {
        //this "for loop" pulls a random tag and dialogue from the lists and puts them in current dialogue/tag
        for( int i = 0;i < 3;i++ ) {
            int randomSelect = Random.Range(0, categoriesList.Count);
            List<string> randomTagList = new List<string> { tagsList[randomSelect] };
            currentTags[i] = randomTagList[Random.Range(0, randomTagList.Count)];
            List<string> randomDialogueList = new List<string>(categoriesList[randomSelect]);
            currentDialogue[i] = randomDialogueList[Random.Range(0, randomDialogueList.Count)];
        }
    }

    //this function updates text and tag on buttons
    void UpdateDialogue() {
        //goes through each PlayerOptions script and changes relevant dialogue and tag
        for( int i = 0;i < 3;i++ ) {
            optionsList[i].ChangeDialogue(currentDialogue[i], currentTags[i]);
        }
    }
}
