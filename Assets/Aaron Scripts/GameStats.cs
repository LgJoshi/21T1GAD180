using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    GameStats myGame;

    string gameName;
    string tagOne;
    string tagTwo;
    string tagThree;

    public void SetupGameStats(string newName, string newTagOne, string newTagTwo, string newTagThree)
    {
        //sets name and stats
        gameName = newName;
        tagOne = newTagOne;
        tagTwo = newTagTwo;
        tagThree = newTagThree;
    }

/*    public bool GetGameA()
    {
        return gameA;
    }

   public void ChangeGameA(bool newGameA)
    {
        gameA = newGameA;
    }

    public bool GetGameB()
    {
        return gameB;
    }

    public void ChangeGameB(bool newGameB)
    {
        gameB = newGameB;
    }

    public bool GetGameC()
    {
        return gameC;
    }

    public void ChangeGameC(bool newGameC)
    {
        gameC = newGameC;
    }*/
}

