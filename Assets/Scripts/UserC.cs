using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserC : MonoBehaviour
{
    public List<string> tags;
    public GameMaster gm;
    public UserJoin userJoin;
    public TimerScript timer;

    public int myUserPic;

    public string myUserName;
    public string tagOne;
    public string tagTwo;
    public string tagThree;
    public string offline;

    //text boxes for names/tags
    public Text userNameText;
    public Text tagTextOne;
    public Text tagTextTwo;
    public Text tagTextThree;


    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite mySprite;

    //just a random int to determine which profile pic is used
    public int profilePic;

    public int userNumber = 2;
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

        //sets username at start
        myUserName = "Sam";
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
        if (join == true)
        {
            if (timer.win == false)
            {
                timer.win = true;
            }
        }

        if(Input.GetKeyDown("h"))
            {
            mood = 100;
            }
    }

    //sets profile pic based on random number
    public void GetPic()
    {
        if (profilePic <= 29)
        {
            mySprite = sprite1;
            spriteRenderer.sprite = mySprite;
            myUserPic = 301;
        }

        else if (profilePic >= 30 && profilePic <= 59)
        {
            mySprite = sprite2;
            spriteRenderer.sprite = mySprite;
            myUserPic = 302;
        }

        else if (profilePic >= 60 && profilePic <= 89)
        {
            mySprite = sprite3;
            spriteRenderer.sprite = mySprite;
            myUserPic = 303;
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
            //if mood reaches 100, joins call
            if (mood == 100)
            {
                join = true;
                active = false;
                userJoin.userJoin();
                panelDull();
            }

            //if mood reaches 0, leaves chat
            if (mood == 0)
            {
                active = false;
                //changes info box on user panel
                tagTextOne.text = offline;
                Destroy(tagTextTwo);
                Destroy(tagTextThree);
                panelDull();
            }

            dialogueTag = gm.GetSelectedTag();

            //if mood is between 0 and 100, check will be made
            if (mood > 0 && mood < 100)
            {
                //if the dialogue tag matches any of the user tags, mood increased by 10
                if (dialogueTag == tagOne || dialogueTag == tagTwo || dialogueTag == tagThree)
                {
                    mood = mood + 10;
                }
                //if no match found, mood decreased by 10
                else
                {
                    mood = mood - 10;
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

    //subs and unsubs from dialogue check event
    void OnEnable()
    {
        EventManager.OptionEvent += DialogueCheck;
    }
    void OnDisable()
    {
        EventManager.OptionEvent -= DialogueCheck;
    }

    public int GetMyImage()
    {
        return myUserPic;
    }
}
