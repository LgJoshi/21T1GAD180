using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerOptions optionOne;
    public PlayerOptions optionTwo;
    public PlayerOptions optionThree;


    void Start()
    {
        optionOne.ChangeDialogue("hello", "banana");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
