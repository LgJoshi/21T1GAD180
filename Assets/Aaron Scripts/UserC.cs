using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserC : MonoBehaviour
{
    public List<string> tags;

    public TagsList tagList;

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
    int mood = 40;

    // Start is called before the first frame update
    void Awake()
    {
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
        tagList.GetTags(tagOne, tagTwo, tagThree);
        tagTextOne.text = tagList.tagOne;
        tagTextTwo.text = tagList.tagTwo;
        tagTextThree.text = tagList.tagThree;
    }

    private void Update()
    {
        if (mood == 0)
        {
            leave = true;
            panelDull();
            //lock out interaction
        }

        if (mood == 100)
        {
            join = true;
            panelDull();
            //add user to call panel
            //lock out interaction
        }

        //need to adjust below once gameTimer is added
        /*if (mood <= 99 && gameTimer == 0)
        {
            leave = true;
            panelDull();
            //lock interaction
        }*/

        tagList.DialogueCheck();
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
}
