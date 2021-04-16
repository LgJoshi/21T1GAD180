using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueExample : MonoBehaviour
{
    public TagsList tagList;
    string tagOne = "FPS";
    string tagTwo = "Co-Op";
    string tagThree = "Action";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            print("Do you want to play this, it has " + tagList.tagOne);
        }
        if (Input.GetKeyDown("2"))
        {
            print("How about we play this, it has " + tagList.tagTwo);
        }
        if (Input.GetKeyDown("3"))
        {
            print("Can we play this, it has " + tagList.tagThree);
        }
    }
}
