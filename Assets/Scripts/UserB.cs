using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserB : MonoBehaviour
{
    public List<string> tags;
    public GameMaster gm;
    public UserJoin userJoin;

    public string userName;
    public string tagOne;
    public string tagTwo;
    public string tagThree;
    public string offline;

    //text boxes for names/tags
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
    public int mood = 40;

    public string dialogueTag;

    // Start is called before the first frame update
    void Awake()
    {
        tags = new List<string>();

        tags.Add("FPS");
        tags.Add("PvP");
        tags.Add("Action");
        tags.Add("Sports");
        tags.Add("Co-Op");
        tags.Add("Survival");
        tags.Add("Adventure");
        tags.Add("Crafting");
        tags.Add("Sandbox");
        tags.Add("Competitive");
        tags.Add("Tactical");


        pic1.enabled = false;
        pic2.enabled = false;
        pic3.enabled = false;

        //sets username at start
        userName = "Jenny";
        userNameText.text = userName;
        //executes GetPic on start
        profilePic = (Random.Range(0, 89));
        GetPic();
        //executes GetTags on start
        GetTags(tagOne, tagTwo, tagThree);
        tagTextOne.text = tagOne;
        tagTextTwo.text = tagTwo;
        tagTextThree.text = tagThree;
        offline = "User is offline";

    }

    private void Update()
    {
       

        //need to adjust below once gameTimer is added
        /*if (mood <= 99 && gameTimer == 0)
        {
            leave = true;
            panelDull();
            //lock interaction
        }*/

        if(Input.GetKeyDown("r"))
        {
            mood = 100;
        }

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

    void panelDull()
    {
        userNameText.color = new Color(1, 1, 1, 0.2f);
        tagTextOne.color = new Color(1, 1, 1, 0.2f);
        tagTextTwo.color = new Color(1, 1, 1, 0.2f);
        tagTextThree.color = new Color(1, 1, 1, 0.2f);
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

    public void DialogueCheck()
    {
        dialogueTag = gm.GetSelectedTag();
        //need to have a connection to GM,have a tag actually set to call on. Then can check it against the user tags

        if (mood == 0)
        {
            leave = true;
            //changes info box on user panel
            tagTextOne.text = offline;
            Destroy(tagTextTwo);
            Destroy(tagTextThree);
            panelDull();
            //lock out interaction
        }

        if (mood == 100)
        {
            join = true;
            panelDull();
            userJoin.userJoin(userName);
            //lock out interaction
        }

        if (mood > 0 && mood < 100)
        {
            if (dialogueTag == tagOne || dialogueTag == tagTwo || dialogueTag == tagThree)
            {
                mood = mood + 10;
            }
            else
            {
                mood = mood - 10;
            }
        }
    }

    public string GetUserName()
    {
        return userName;
    }

    public bool GetJoin()
    {
        return join;
    }

    void OnEnable()
    {
        EventManager.OptionEvent += DialogueCheck;
    }
    void OnDisable()
    {
        EventManager.OptionEvent -= DialogueCheck;
    }
}
