using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBSetup : MonoBehaviour
{
    string myName = "Warcraft";
    string tagOne = "RTS";
    string tagTwo = "Fantasy";
    string tagThree = "Multi";

    private void Awake()
    {
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

    public string GetNameB()
    {
        return myName;
    }
}
