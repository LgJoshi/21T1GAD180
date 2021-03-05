using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameASetup : MonoBehaviour
{
    string myName = "Call of Duty";
    string tagOne = "FPS";
    string tagTwo = "Multi";
    string tagThree = "Battle Royale";

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

    public string GetNameA()
    {
        return myName;
    }


}
