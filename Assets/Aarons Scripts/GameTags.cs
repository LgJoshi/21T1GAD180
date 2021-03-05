using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTags : MonoBehaviour
{
    //public string gameTags;
    List<string> tagsList = new List<string>();

    public string firstTag;
    public string secondTag;
    public string thirdTag;

    // Start is called before the first frame update
    void Start()
    {
        //tags added to list
        tagsList.Add("Action");
        tagsList.Add("Adventure");
        tagsList.Add("RPG");
        tagsList.Add("MMO");
        tagsList.Add("Fantasy");
        tagsList.Add("FPS");
        tagsList.Add("Combat");
        tagsList.Add("Magic");
        tagsList.Add("Rogue Like");
        tagsList.Add("Fighting");
        tagsList.Add("Sci Fi");
        tagsList.Add("Horror");
        tagsList.Add("Zombies");
        tagsList.Add("Simulation");
        tagsList.Add("Strategy");
        tagsList.Add("Puzzle");
        tagsList.Add("Platformer");
        tagsList.Add("Sandbox");
        tagsList.Add("Turn Based");
        tagsList.Add("Mystery");
        tagsList.Add("Tactical");
        tagsList.Add("Dungeon Crawler");
        tagsList.Add("Stealth");
        tagsList.Add("Sports");
        tagsList.Add("Racing");
        tagsList.Add("Arcade");
        tagsList.Add("Co-Op");
        tagsList.Add("PvP");
        tagsList.Add("Top Down");
        tagsList.Add("Building");
        tagsList.Add("PvE");
        tagsList.Add("Crafting");
        tagsList.Add("Base Building");
        tagsList.Add("RTS");
        tagsList.Add("Survival");

        GetTagOne();
        GetTagTwo();
        GetTagThree();
       
    }

    public void GetTagOne()
    {
        //selects first tag, then removes from list
        firstTag = tagsList[Random.Range(0, 33)];
        //tagOne = firstTag;
        print("Tag one = " + firstTag);
        //tagsList.Remove(firstTag);
    }

    public void GetTagTwo()
    {
        //selects second tag, then removes from list
        string secondTag = tagsList[Random.Range(0, 33)];
        //tagTwo = secondTag;
        print("Tag two = " + secondTag);
        //tagsList.Remove(secondTag);
    }

    public void GetTagThree()
    {
        //creates third tag
        string thirdTag = tagsList[Random.Range(0, 33)];
        //tagThree = thirdTag;
        print("Tag three = " + thirdTag);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
