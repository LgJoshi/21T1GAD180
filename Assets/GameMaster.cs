using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerOptions optionOne;
    public PlayerOptions optionTwo;
    public PlayerOptions optionThree;

    public UserA userA;
    public UserB userB;
    public UserC userC;


    void Start()
    {
        

    }

    public void DialogueChosen(int buttonNumber) {
        if( buttonNumber == 1 ) {
            optionOne.GetTag
        }
        optionOne.ChangeDialogue("hello", "banana");
        EventManager.ButtonPress();
    }
}
