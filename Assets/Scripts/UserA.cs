using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserA : MonoBehaviour
{

    public List<string> tags;
    public GameMaster gm;
    public UserJoin userJoin;
    public TimerScript timer;

    public Image[] userPicsArray;
    public int myUserPic;

    public UserPics userpics;

    public string myUserName;
    public string tagOne;
    public string tagTwo;
    public string tagThree;
    public string offline;

    //text boxes for name/tags
    public Text userNameText;
    public Text tagTextOne;
    public Text tagTextTwo;
    public Text tagTextThree;

    //profile pic locations
    public Image pic1;
    public Image pic2;
    public Image pic3;

    //random int to determine which profile pic is used
    public int profilePic;

    public int userNumber = 0;
    public bool active = true;
    public bool positive;

    public bool join = false;
    int mood = 50;

    public string dialogueTag;

    // Start is called before the first frame update
    void Awake()
    {

        //creates list of tags
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

        //hides profiles pics until further notice
        pic1.enabled = false;
        pic2.enabled = false;
        pic3.enabled = false;

        //sets username at start
        myUserName = "Tim";
        userNameText.text = myUserName;

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
        if (Input.GetKeyDown("f"))
        {
            mood = 100;
        }            
    }

    //sets profile pic based on random number
    public void GetPic()
    {
        if (profilePic <= 29)
        {
            pic1.enabled = true;
            myUserPic = 101;
        }

        else if (profilePic >= 30 && profilePic <= 59)
        {
            pic2.enabled = true;
            myUserPic = 102;
        }

        else if (profilePic >= 60 && profilePic <= 89)
        {
            pic3.enabled = true;
            myUserPic = 103;
        }
    }

    //dulls text to signify user not interactable
    void panelDull()
    {
        userNameText.color = new Color(1, 1, 1, 0.2f);
        tagTextOne.color = new Color(1, 1, 1, 0.2f);
        tagTextTwo.color = new Color(1, 1, 1, 0.2f);
        tagTextThree.color = new Color(1, 1, 1, 0.2f);
    }

    //gets user's tags
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

    //compares dialogue tag to user tags
    public void DialogueCheck()
    {
        if (active == true)
        {
            if (join == true)
            {
                if (timer.win == false)
                {
                    timer.win = true;
                }
            }

            //if mood reaches 0, leaves chat
            if (mood <= 0)
            {
                active = false;
                //changes info box on user panel
                tagTextOne.text = offline;
                Destroy(tagTextTwo);
                Destroy(tagTextThree);
                panelDull();
            }

            //if mood reaches 100, joins call
            if (mood == 100)
            {
                join = true;
                userJoin.userJoin();
                panelDull();
                active = false;
            }

            dialogueTag = gm.GetSelectedTag();
            //if mood is between 0 and 100, check will be made
            if (mood > 0 && mood < 100)
            {
                //if the dialogue tag matches any of the user tags, mood increased by 10
                if (dialogueTag == tagOne || dialogueTag == tagTwo || dialogueTag == tagThree)
                {
                    mood = mood + 10;
                    positive = true;
                }
                //if no match found, mood decreased by 10
                else
                {
                    mood = mood - 10;
                    positive = false;
                }
            }
            gm.UserStuff(userNumber, active, positive);
        }
    }

    //returns join bool status
    public bool GetJoin()
    {
        return join;
    }

    //returns user's name
    public string GetMyName()
    {
        return myUserName;
    }

    public int GetMyImage()
    {
        return myUserPic;
    }

    //subs and unsubs from dialogue check event
    void OnEnable()
    {
        EventManager.OptionEvent += DialogueCheck;
    }
    void OnDisable()
    {
        EventManager.OptionEvent -= DialogueCheck;
    }

}
