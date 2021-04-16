using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserJoin : MonoBehaviour
{
    //text box
    public TMP_Text userNameJoin;

    //links user scripts
    public UserA userA;
    public UserB userB;
    public UserC userC;

    //self explanatory
    public string userNameA;
    public string userNameB;
    public string userNameC;

    public List<string> joined;

    void Start()
    {
        //creates the list
        List<string> joined = new List<string>();
       
        //gets user's names
        userNameA = userA.GetMyName();
        userNameB = userB.GetMyName();
        userNameC = userC.GetMyName();     
    }

    public void userJoin()
    {
        //checks userA join and if the list DOESN'T contain the name
        if (userA.GetJoin() == true && !joined.Contains("Tim"))
        {
            //adds user to the join list, prints list to joined panel
            joined.Add(userNameA);
            CheckJoined();
        }
        //else
        //checks userB join and if the list DOESN'T contain the name
        else if (userB.GetJoin() == true && !joined.Contains("Jenny"))
        {
            //adds user to the join list, prints list to joined panel
            joined.Add(userNameB);
            CheckJoined();
        }
        //else
        //checks userC join and if the list DOESN'T contain the name
        else if (userC.GetJoin() == true && !joined.Contains("Sam"))
        {
            //adds user to the join list, prints list to joined panel
            joined.Add(userNameC);
            CheckJoined();
        }     
    }   

    void CheckJoined()
    {
        //converts list to string, prints to joined panel
        string text = string.Join("\n", joined.ToArray());
        userNameJoin.text = (text);
    }

    private void Update()
    {
       
    }

}
