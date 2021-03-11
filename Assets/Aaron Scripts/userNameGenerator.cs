using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userNameGenerator : MonoBehaviour
{
    public List<string> userNames;

    string userNameA;
    string userNameB;
    string userNameC;


    // Start is called before the first frame update
    void Start()
    {

        userNames = new List<string>();
        userNames.Add("Bill");
        userNames.Add("Jane");
        userNames.Add("Jenny");
        userNames.Add("Tom");
        userNames.Add("Roger");
        userNames.Add("Diane");
        userNames.Add("Cedric");
        SetUsername(userNameA, userNameB, userNameC);
        print(userNameA);

        print(userNameC);

    }

    public void SetUsername(string newUserNameA, string newUserNameB, string newUserNameC)
    {
        userNameA = newUserNameA;
        userNameB = newUserNameB;
        userNameC = newUserNameC;

        for (int i = 0; i <= 0; i++)
        {
            userNameA = userNames[Random.Range(0, userNames.Count)];
            print("Username Generator = " + userNameA);
            userNames.Remove(userNameA);
            

            userNameB = userNames[Random.Range(0, userNames.Count)];
            print("Username Generator = " + userNameB);
            userNames.Remove(userNameB);

            userNameC = userNames[Random.Range(0, userNames.Count)];
            print("Username Generator = " + userNameC);
            userNames.Remove(userNameC);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
