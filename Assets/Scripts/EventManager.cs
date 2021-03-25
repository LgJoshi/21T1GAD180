using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Defines event variable related to the activation of the button
    public delegate void UpdateOptions();
    public static event UpdateOptions OptionEvent;

    static public void OptionsChosen() 
    {
        EventManager.OptionEvent();
    }

    
}
