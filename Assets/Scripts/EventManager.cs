using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Defines event variable related to the activation of the button
    public delegate void UpdateOptions();
    public static event UpdateOptions OptionEvent;

    static public void OptionsChosen() {
        EventManager.OptionEvent();
    }

    public delegate void StartGame();
    public static event StartGame StartEvent;

    static public void GameStarted() {
        EventManager.StartEvent();
    }

    public delegate void EndGame();
    public static event EndGame EndEvent;
    
    static public void GameEnded(){
        EventManager.EndEvent();
    }

    public delegate void ChatUpdate();
    public static event ChatUpdate ChatUpdateEvent;

    static public void ChatUpdated() {
        EventManager.ChatUpdateEvent();
    }

    public delegate void ChatScroll();
    public static event ChatScroll ChatScrollEvent;

    static public void ChatScrolled() {
        EventManager.ChatScrollEvent();
    }

    public delegate void TimerEnding();
    public static event TimerEnding TimeSpeedEvent;

    static public void TimerSpeedup() {
        EventManager.TimeSpeedEvent();
    }
}
