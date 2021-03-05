using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    string myName = "The Player";
    // Start is called before the first frame update
    private void Awake()
    {
        this.GetComponent<UserStats>().PlayerSetupStats(myName);
    }
}