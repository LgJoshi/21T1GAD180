using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserJoin : MonoBehaviour
{
    public TMP_Text userNameJoin;
    public UserA userA;
    public UserB userB;
    public UserC userC;

    public string userNameA;
    public string userNameB;
    public string userNameC;

    public List<string> stuff;
    public int listLength;
    public int unCheck;

    void Start()
    {
        List<string> stuff = new List<string>();
       
        userNameA = userA.GetMyName();
        userNameB = userB.GetMyName();
        userNameC = userC.GetMyName();     
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void userJoin()
    {

            if (userA.GetJoin() == true && !stuff.Contains("Tim"))
            {
                stuff.Add(userNameA);
                CheckStuff();
            }
            //else
            if (userB.GetJoin() == true && !stuff.Contains("Jenny"))
            {
                stuff.Add(userNameB);
                CheckStuff();
            }
            //else
            if (userC.GetJoin() == true && !stuff.Contains("Sam"))
            {
                stuff.Add(userNameC);
                CheckStuff();
            }

        

    }   

    void CheckStuff()
    {
        string text = string.Join("\n", stuff.ToArray());
        userNameJoin.text = (text);
    }


}
