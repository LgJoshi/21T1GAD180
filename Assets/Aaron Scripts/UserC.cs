using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserC : MonoBehaviour
{
    public List<string> tags;

    public string userName;
    public string tagOne;
    public string tagTwo;
    public string tagThree;

    //text boxes for name/tags
    public Text userNameText;
    public Text tagTextOne;
    public Text tagTextTwo;
    public Text tagTextThree;

    //profile pic locations
    public Image pic1;
    public Image pic2;
    public Image pic3;
   
    //just a random int to determine which profile pic is used
    public int profilePic;

    //bools to be used later in development
    bool join = false;
    bool leave = false;

    // Start is called before the first frame update
    void Awake()
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

        pic1.enabled = false;
        pic2.enabled = false;
        pic3.enabled = false;

        //sets username at start
        userName = "Sam";
        userNameText.text = "Sam";
        //executes GetPic on start
        profilePic = (Random.Range(0, 89));
        GetPic();
        //executes GetTags on start
        GetTags(tagOne, tagTwo, tagThree);        
    }

    public void GetPic()
    {
        if (profilePic <= 29)
        {
            pic1.enabled = true;
        }

        else if (profilePic >= 30 && profilePic <= 59)
        {
            pic2.enabled = true;
        }

        else if (profilePic >= 60 && profilePic <= 89)
        {
            pic3.enabled = true;
        }
    }


    public void GetTags(string newTagOne, string newTagTwo, string newTagThree)
    {
        tagOne = newTagOne;
        tagTwo = newTagTwo;
        tagThree = newTagThree;

        for (int i = 0; i <= 0; i++)
        {
            //selects tagOne as a random number in the list between 0 & 9, prints to console
            tagOne = tags[Random.Range(0, tags.Count)];
            print("Tag One = " + tagOne);
            tagTextOne.text = tagOne;
            tags.Remove(tagOne);
            //selects tagTwo as a random number in the list between 0 & 9, prints to console
            tagTwo = tags[Random.Range(0, tags.Count)];
            print("Tag Two = " + tagTwo);
            tagTextTwo.text = tagTwo;
            tags.Remove(tagTwo);
            //selects tagThree as a random number in the list between 0 & 9, prints to console
            tagThree = tags[Random.Range(0, tags.Count)];
            print("Tag Three = " + tagThree);
            tagTextThree.text = tagThree;
            tags.Remove(tagThree);
        }

    }

}
