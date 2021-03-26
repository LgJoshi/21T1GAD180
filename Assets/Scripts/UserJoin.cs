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

    public string userName1;
    public string userName2;
    public string userName3;

    // Start is called before the first frame update
    void Start()
    {
        userName1 = userA.GetUserName();
        userName2 = userB.GetUserName();
        userName3 = userC.GetUserName();       
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void userJoin(string userName)
    {
        if (userA.GetJoin() == true)
        {
            userNameJoin.text = userName1;
        }
        if(userB.GetJoin() == true)
        {
            userNameJoin.text += "\n" + userName2;
        }
        if(userC.GetJoin() == true)
        {
            userNameJoin.text += "\n" + userName3;
        }
    }

}
