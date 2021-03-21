using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TagsList : MonoBehaviour
{
    public List<string> tags;
    public GameMaster gm;

    /*    public enum tags
        {
            FPS,
            PvP,
            Action,
            StoryDriven,
            CoOp,
            Survival,
            Adventure,
            Crafting,
            Sandbox,
            Competitive
        }
    */
    public string tagOne;
    public string tagTwo;
    public string tagThree;

    public int mood;

    public string dialogueTag;
    // Start is called before the first frame update
    void Awake()
    {
        //dialogueTag = (need a tag to call on in GM)
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

    }

    public void GetTags(string newTagOne, string newTagTwo, string newTagThree)
    {

        for (int i = 0; i <= 0; i++)
        {
            //selects tagOne as a random number in the list between 0 & 9, prints to console
            tagOne = tags[Random.Range(0, tags.Count)];
            print("Tag One = " + tagOne);
            //tagTextOne.text = tagOne;
            tags.Remove(tagOne);
            //selects tagTwo as a random number in the list between 0 & 9, prints to console
            tagTwo = tags[Random.Range(0, tags.Count)];
            print("Tag Two = " + tagTwo);
            //tagTextTwo.text = tagTwo;
            tags.Remove(tagTwo);
            //selects tagThree as a random number in the list between 0 & 9, prints to console
            tagThree = tags[Random.Range(0, tags.Count)];
            print("Tag Three = " + tagThree);
            //tagTextThree.text = tagThree;
            tags.Remove(tagThree);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DialogueCheck()
    {
        //need to have a connection to GM,have a tag actually set to call on. Then can check it against the user tags

        if(dialogueTag == tagOne || dialogueTag == tagTwo || dialogueTag == tagThree)
        {
            mood = mood + 10;
        }
        else
        {
            mood = mood - 10;
        }
    }
}
