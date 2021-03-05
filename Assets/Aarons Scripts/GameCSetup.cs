using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCSetup : MonoBehaviour
{
    string myName = "Fable";
    string tagOne = "Fantasy";
    string tagTwo = "RPG";
    string tagThree = "Magic";

    private void Awake()
    {
        //sets up name and stats
        this.GetComponent<GameStats>().SetupGameStats(name, tagOne, tagTwo, tagThree);
    }

    public void DialogueOne()
    {
        print("Hey, do you want to play " + myName + "?");
        print("It's got " + tagOne + ".");
    }

    public void DialogueTwo()
    {
        print("Hey, do you want to play " + myName + "?");
        print("It's got " + tagTwo + ".");
    }

    public void DialogueThree()
    {
        print("Hey, do you want to play " + myName + "?");
        print("It's got " + tagThree + ".");
    }

    public string GetNameC()
    {
        return myName;
    }
}
