using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public int selectedGame;
    public int GetSelectedGame() {
        return selectedGame;
    }

    //
    //
    //variables of chatbox stuff
    string[] positiveResponse;
    string[] negativeResponse;
    string[] textHistory;
    int historySelect;

    bool[] activeStates;
    bool[] responseStates;
    int activeUsers;

    public TextMeshProUGUI[] textArray;
    //
    //
    //

    void OnEnable() {
        EventManager.ChatUpdateEvent += updateResponses;
    }
    void OnDisable() {
        EventManager.ChatUpdateEvent -= updateResponses;
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

        //
        //
        //
        //all this stuff below is chatbox stuff
        //positiveResponse = new string[] { "111111111111111", "22222222222222", "333333333333333", "44444444444" };
        positiveResponse = new string[] { "That sounds good", "That sounds promising", "Oooooooo", "You've piqued my interest" };
        negativeResponse = new string[] { "Meh", "I dunno" };

        textHistory = new string[] { "1a", "2b", "3c", "4d", "5e", "6f", "7g", "8h" };
        historySelect = 2;

        activeStates = new bool[] { true, true, true };
        responseStates = new bool[] { true, true, true };
        activeUsers = 3;
        //
        //
        //
    }

    private void Update() {
        //debug button. press 1 to see current tags on buttons.
        if( Input.GetKeyDown("1") ) {
            print("Tag 1 is " + currentTags[0]);
            print("Tag 2 is " + currentTags[1]);
            print("Tag 3 is " + currentTags[2]);
            print("active users is " + activeUsers);
            print("text history:");
            print(textHistory[0]);
            print(textHistory[1]);
            print(textHistory[2]);
            print(textHistory[3]);
            print(textHistory[4]);
            print(textHistory[5]);
            print(textHistory[6]);
            print(textHistory[7]);
        }
    }
    //int tagOne, int tagTwo, int tagThree, int tagFour, int tagFive
    public void GameSetup( string tagInput ) {
        string[] values = tagInput.Split(',');
        int[] convertedValues = System.Array.ConvertAll<string, int>(values, int.Parse);
        selectedGame = convertedValues[0];

        //These are the lists which can be manipulated and changed for new dialogue and tags
        tagsList = new List<string> { tags[convertedValues[1]], tags[convertedValues[2]], tags[convertedValues[3]], tags[convertedValues[4]], tags[convertedValues[5]] };
        categoriesList = new List<string[]> { dialogueCategories[convertedValues[1]], dialogueCategories[convertedValues[2]], dialogueCategories[convertedValues[3]], dialogueCategories[convertedValues[4]], dialogueCategories[convertedValues[5]] };

        textHistory[1] = "I'm looking for people to play " + textArray[selectedGame].text + "!";

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
        EventManager.ChatUpdated();
        EventManager.ChatScrolled();
        
        //debugger text
        print("button "+(buttonNumber+1)+" pressed");

        
        NewDialogue();
        DelayUpdate();
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

    void DelayUpdate() {
        StartCoroutine(DelayDialogue());
    }
    IEnumerator DelayDialogue() {
        yield return new WaitForSeconds(3);
        UpdateDialogue();
    }

    //this function updates text and tag on buttons
    void UpdateDialogue() {
        //goes through each PlayerOptions script and changes relevant dialogue and tag
        for( int i = 0;i < 3;i++ ) {
            optionsList[i].ChangeDialogue(currentDialogue[i], currentTags[i]);
        }
    }


    //
    //
    //
    //all this stuff below is chatbox stuff
    public void UserStuff(int userNumber, bool active, bool positive) {
        activeStates[userNumber] = active;
        responseStates[userNumber] = positive;
        if( !active ) {
            activeUsers=activeUsers-1;
        }
    }
    void updateResponses() {
        //updates chatbox 3 (hopefully) to = selected dialogue since it represents the player for the first chat input
        textHistory[historySelect] = selectedDialogue;
        IncrementHistorySelect();

        if( activeStates[0] ) {
            if( responseStates[0] ) {
                textHistory[historySelect] = positiveResponse[Random.Range(0, positiveResponse.Length)];
            } else {
                textHistory[historySelect] = negativeResponse[Random.Range(0, negativeResponse.Length)];
            }
            IncrementHistorySelect();
        }
        if( activeStates[1] ) {
            if( responseStates[1] ) {
                textHistory[historySelect] = positiveResponse[Random.Range(0, positiveResponse.Length)];
            } else {
                textHistory[historySelect] = negativeResponse[Random.Range(0, negativeResponse.Length)];
            }
            IncrementHistorySelect();
        }
        if( activeStates[2] ) {
            if( responseStates[2] ) {
                textHistory[historySelect] = positiveResponse[Random.Range(0, positiveResponse.Length)];
            } else {
                textHistory[historySelect] = negativeResponse[Random.Range(0, negativeResponse.Length)];
            }
            IncrementHistorySelect();
        }
        print("text history:");
        print(textHistory[0]);
        print(textHistory[1]);
        print(textHistory[2]);
        print(textHistory[3]);
        print(textHistory[4]);
        print(textHistory[5]);
        print(textHistory[6]);
        print(textHistory[7]);
    }
    void IncrementHistorySelect() {
        historySelect++;
        if( historySelect >= 8 ) {
            historySelect = 0;
        }
    }
    public int GetActiveUsers() {
        return activeUsers;
    }
    public string[] GetTextHistory() {
        return textHistory;
    }
}