using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TagsList : MonoBehaviour
{
    public List<string> tags;

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
    // Start is called before the first frame update
    void Awake()
    {

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

    //public List<string> userList = new List<string>();
}
