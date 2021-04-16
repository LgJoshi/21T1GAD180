using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBSetup : MonoBehaviour
{
    public string userName = "User B";
    public string tagOne = "Arcade";
    public string tagTwo = "Co-Op";
    public string tagThree = "Rogue Like";

    bool join = false;
    bool leave = false;



    void awake()
    {
        this.GetComponent<UserStats>().SetupStats(userName, tagOne, tagTwo, tagThree, join, leave);
    }

}
