using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserASetup : MonoBehaviour
{
    public string userName = "User A";
    public string tagOne = "FPS";
    public string tagTwo = "Battle Royale";
    public string tagThree = "Multiplayer";

    bool join = false;
    bool leave = false;



    void awake()
    {
        this.GetComponent<UserStats>().SetupStats(userName, tagOne, tagTwo, tagThree, join, leave);
    }

}
