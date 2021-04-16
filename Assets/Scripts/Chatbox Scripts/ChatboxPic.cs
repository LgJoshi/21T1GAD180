using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatboxPic : MonoBehaviour
{
    public int historyNumber;
    int spriteSelect;
    int historySelect;

    public Sprite[] userPics;
    SpriteRenderer spriteRenderer;
    GameMaster gameMaster;
    Sprite[] spriteHistory;

    /*
    UserA userAScript;
    UserB userBScript;
    UserC userCScript;
    */

    Image userAImage;
    Image userBImage;
    Image userCImage;

    float timeSpan;
    float chatDelay;
    int activeUsers;

    

    void OnEnable() {
        EventManager.StartEvent += StartupPic;
        EventManager.OptionEvent += ChatPicScroll;
        EventManager.EndEvent += StopGame;
    }
    void OnDisable() {
        EventManager.StartEvent -= StartupPic;
        EventManager.OptionEvent -= ChatPicScroll;
        EventManager.EndEvent -= StopGame;
    }

    void Awake()
    {
        //if this is changed, make sure it matches chatboxchat
        timeSpan = 4;

        chatDelay = timeSpan/4;
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        spriteHistory = new Sprite[] { userPics[0], userPics[3], userPics[3], userPics[3], userPics[0], userPics[1], userPics[2], userPics[3] };

        /*
        userAImage = GameObject.Find("UserA").GetComponentInChildren<Image>();
        userBImage = GameObject.Find("UserB").GetComponentInChildren<Image>();
        userCImage = GameObject.Find("UserC").GetComponentInChildren<Image>();

        userPics[0] = userAImage.sprite;
        userPics[1] = userBImage.sprite;
        userPics[2] = userCImage.sprite;
        */
        gameMaster = GameObject.Find("Master").GetComponent<GameMaster>();
        activeUsers = 3;
        spriteSelect = historyNumber;
        historySelect = 2;

        spriteRenderer.enabled = false;
    }

    void StartupPic() {
        StartCoroutine(StartupScroll());
    }

    IEnumerator StartupScroll() {
        yield return new WaitForSeconds(1.5f);
        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = spriteHistory[2];
            yield return new WaitForSeconds(chatDelay);
            spriteRenderer.enabled = false;
        }
        if( historyNumber == 2 ) {
            yield return new WaitForSeconds(chatDelay);
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = spriteHistory[2];
        }
    }

    void UpdatePicHistory() {
        bool[] activeStates = gameMaster.GetActiveStates();
        spriteHistory[historySelect] = userPics[3];
        IncrementHistorySelect();

        if( activeStates[0] ) {
            spriteHistory[historySelect] = userPics[0];
            IncrementHistorySelect();
        }
        if( activeStates[1] ) {
            spriteHistory[historySelect] = userPics[1];
            IncrementHistorySelect();
        }
        if( activeStates[2] ) {
            spriteHistory[historySelect] = userPics[2];
            IncrementHistorySelect();
        }
    }
    void IncrementHistorySelect() {
        historySelect++;
        if( historySelect >= 8 ) {
            historySelect = 0;
        }
    }

    void ChatPicScroll() {
        UpdatePicHistory();
        activeUsers = gameMaster.GetActiveUsers();
        StartCoroutine(ScrollPic());
    }

    IEnumerator ScrollPic() {

        //if this is changed, make sure it matches chatboxchat and playeroptions
        yield return new WaitForSeconds(1.5f);

        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
            if( spriteSelect == 0 ) {
                spriteRenderer.sprite = spriteHistory[7];
            } else {
                spriteRenderer.sprite = spriteHistory[spriteSelect - 1];
            }
        }

        yield return new WaitForSeconds(chatDelay);

        for( int i = 0;i < activeUsers;i++ ) {
            if( spriteSelect == 1 ) {
                spriteRenderer.enabled = true;
            }
            spriteRenderer.sprite = spriteHistory[spriteSelect];
            IncrementSpriteSelect();
            yield return new WaitForSeconds(chatDelay);
        }
        spriteRenderer.sprite = spriteHistory[spriteSelect];
        IncrementSpriteSelect();
        if( historyNumber == 3 ) {
            spriteRenderer.enabled = false;
        }
    }

    void IncrementSpriteSelect() {
        spriteSelect++;
        if( spriteSelect >= 8 ) {
            spriteSelect = 0;
        }
    }

    void StopGame() {
        StopAllCoroutines();
    }
}
