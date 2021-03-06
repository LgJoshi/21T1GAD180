using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public List<string> tags;
    public List<string> userNames;

    public string userName = "Bill";
    public string tagOne;
    public string tagTwo;
    public string tagThree;

    //bools to be used later in development
    bool join = false;
    bool leave = false;

    // Start is called before the first frame update
    void Start()
    {
        //creates new list of tags
        tags = new List<string>();
        tags.Add("FPS");
        tags.Add("PvP");
        tags.Add("Action");
        tags.Add("Story Driven");
        tags.Add("Co-Op");
        tags.Add("Survival");
        tags.Add("Adventure");
        tags.Add("Crafting");
        tags.Add("Sandbox");
        tags.Add("Competitive");

        userNames = new List<string>();
        userNames.Add("Bill");
        userNames.Add("Jane");
        userNames.Add("Jenny");
        userNames.Add("Tom");
        userNames.Add("Roger");
        userNames.Add("Diane");
        userNames.Add("Cedric");

        //executes GetUsername on start
        GetUsername(userName);
        //executes GetTags on start
        GetTags(tagOne, tagTwo, tagThree);
    }

    public void GetTags(string newTagOne, string newTagTwo, string newTagThree)
    {
        tagOne = newTagOne;
        tagTwo = newTagTwo;
        tagThree = newTagThree;
        //sets range to 3 tags (0 - 2)
        for (int i = 0; i <= 2; i++)
        {
            //selects tagOne as a random number in the list between 0 & 9, prints to console
            tagOne = tags[Random.Range(0, tags.Count)];
            print("Tag One = " + tagOne);
            tags.Remove(tagOne);
            //selects tagTwo as a random number in the list between 0 & 9, prints to console
            tagTwo = tags[Random.Range(0, tags.Count)];
            print("Tag Two = " + tagTwo);
            tags.Remove(tagTwo);
            //selects tagThree as a random number in the list between 0 & 9, prints to console
            tagThree = tags[Random.Range(0, tags.Count)];
            print("Tag Three = " + tagThree);
            tags.Remove(tagThree);
        }

    }

    public void GetUsername(string newUserName)
    {
        userName = newUserName;

        for(int i = 0; i < 1; i++)
        {
            userName = userNames[Random.Range(0, 6)];
            print("Username = " + userName);
            userNames.Remove(this.userName);
        }

    }

    private void Update()
    {
    }





}
