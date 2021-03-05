using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCSetup : MonoBehaviour
{
    public string userName = "User C";
    public string tagOne = "Mystery";
    public string tagTwo = "Platformer";
    public string tagThree = "Fantasy";

    bool join = false;
    bool leave = false;


    void awake()
    {
        this.GetComponent<UserStats>().SetupStats(userName, tagOne, tagTwo, tagThree, join, leave);
    }
}
