using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class userNameGenerator : MonoBehaviour
{
    public List<string> userNames;

    public string nameOne;
    public string nameTwo;
    public string nameThree;


    // Start is called before the first frame update
    void Awake()
    {

        userNames = new List<string>();
        userNames.Add("Bill");
        userNames.Add("Jane");
        userNames.Add("Jenny");
        userNames.Add("Tom");
        userNames.Add("Roger");
        userNames.Add("Diane");
        userNames.Add("Cedric");

        GetUsername(nameOne, nameTwo, nameThree);
        GetNameOne();
        GetNameTwo();
        GetNameThree();
    }

    public void GetUsername(string newNameOne, string newNameTwo, string newNameThree)
    {

        for (int i = 0; i <= 0; i++)
        {
            nameOne = userNames[Random.Range(0, userNames.Count)];
            print("Username Generator = " + nameOne);
            userNames.Remove(nameOne);


            nameTwo = userNames[Random.Range(0, userNames.Count)];
            print("Username Generator = " + nameTwo);
            userNames.Remove(nameTwo);

            nameThree = userNames[Random.Range(0, userNames.Count)];
            print("Username Generator = " + nameThree);
            userNames.Remove(nameThree);
            
        }
    }

    public string GetNameOne()
    {
        return nameOne;
    }

    public string GetNameTwo()
    {
        return nameTwo;
    }

    public string GetNameThree()
    {
        return nameThree;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
