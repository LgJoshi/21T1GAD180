using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    UserStats myStats;

    GameASetup gameA;
    GameBSetup gameB;
    GameCSetup gameC;

    GameStats myGame;

    string gameNameA;
    string gameNameB;
    string gameNameC;

    bool gameOne = false;
    bool gameTwo = false;
    bool gameThree = false;

    bool dialogueOne = true;
    bool dialogueTwo = false;



    // Start is called before the first frame update
    void Start()
    {
        //hopefully gets stats of conversing user
        myGame = GameObject.FindObjectOfType<GameStats>();
        myStats = this.GetComponent<UserStats>();
        //gets names of games
        gameA = GameObject.FindObjectOfType<GameASetup>();
        gameNameA = gameA.GetNameA();
        gameB = GameObject.FindObjectOfType<GameBSetup>();
        gameNameB = gameB.GetNameB();
        gameC = GameObject.FindObjectOfType<GameCSetup>();
        gameNameC = gameC.GetNameC();
        print("Do you want to choose " + gameNameA + "?");
        print("Do you want to choose " + gameNameB + "?");
        print("Do you want to choose " + gameNameC + "?");

    }

    // Update is called once per frame
    void Update()
    {
        //this is where things need work, need to have text options in stages perhaps??
        //atm a key press of 1 will activate multiple dialogues

        if (Input.GetKey("1") && dialogueOne == true)
        {
            print("You chose " + gameNameA + "!");
            dialogueOne = false;
            gameOne = true;
        }

        if (gameOne == true && dialogueTwo == true)
        {
            if (Input.GetKeyDown("1"))
            {
                gameA.DialogueOne();
            }
            if (Input.GetKeyDown("2"))
            {
                gameA.DialogueTwo();
            }
            if (Input.GetKeyDown("3"))
            {
                gameA.DialogueThree();
            }
        }
        dialogueTwo = true;

        if (Input.GetKeyDown("2") && dialogueOne == true)
        {
            print("You chose " + gameNameB + "!");
            dialogueOne = false;
            gameTwo = true;
        }

        if (gameTwo == true && dialogueTwo == true)
        {
            if (Input.GetKeyDown("1"))
            {
                gameB.DialogueOne();
            }
            if (Input.GetKeyDown("2"))
            {
                gameB.DialogueTwo();
            }
            if (Input.GetKeyDown("3"))
            {
                gameB.DialogueThree();
            }
        }
        dialogueTwo = true;

        if (Input.GetKeyDown("3") && (dialogueOne == true))
        {
            print("You chose " + gameNameC + "!");
            dialogueOne = false;
            gameThree = true;
        }

        if (gameThree == true && dialogueTwo == true)
        { 

            if (gameC == true && Input.GetKeyDown("1"))
            {
                gameC.DialogueOne();
            }
            if (gameC == true && Input.GetKeyDown("2"))
            {
                gameC.DialogueTwo();
            }
            if (gameC == true && Input.GetKeyDown("3"))
            {
                gameC.DialogueThree();
            }
        }
        dialogueTwo = true;



    }

}

