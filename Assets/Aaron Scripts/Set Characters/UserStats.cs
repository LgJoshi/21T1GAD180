using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserStats : MonoBehaviour
{
    UserStats myUser;

    string name;
    string tagOne;
    string tagTwo;
    string tagThree;

    bool join;
    bool leave;

    public void SetupStats(string newName, string newTagOne, string newTagTwo, string newTagThree, bool join, bool leave)
    {
        name = newName;
        tagOne = newTagOne;
        tagTwo = newTagTwo;
        tagThree = newTagThree;
        join = false;
        leave = false;
    }

    public void PlayerSetupStats(string newName)
    {
        name = newName;
    }
    
    public bool GetUser()
    {
        return myUser;
    }

    public void ChangeUser(UserStats newUser)
    {
        myUser = newUser;
    }
}
