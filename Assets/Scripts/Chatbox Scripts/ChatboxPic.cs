using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatboxPic : MonoBehaviour
{
    public int historyNumber;
    int spriteSelect;

    public Sprite[] userPics;
    SpriteRenderer spriteRenderer;
    GameMaster gameMaster;

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

        spriteRenderer.enabled = false;
    }

    void StartupPic() {
        StartCoroutine(StartupScroll());
    }

    IEnumerator StartupScroll() {
        yield return new WaitForSeconds(1.5f);
        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = userPics[3];
            yield return new WaitForSeconds(chatDelay);
            spriteRenderer.enabled = false;
        }
        if( historyNumber == 2 ) {
            yield return new WaitForSeconds(chatDelay);
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = userPics[3];
        }
    }

    void ChatPicScroll() {
        spriteSelect = historyNumber;
        activeUsers = gameMaster.GetActiveUsers();
        StartCoroutine(ScrollPic());
    }

    IEnumerator ScrollPic() {

        //if this is changed, make sure it matches chatboxchat and playeroptions
        yield return new WaitForSeconds(1.5f);

        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
        }

        for( int i = 0;i < activeUsers+1;i++ ) {
            spriteRenderer.sprite = userPics[spriteSelect];
            if( spriteSelect == 3 ) {
                spriteRenderer.enabled = true;
            }
            spriteSelect++;
            if( spriteSelect >= 4 ) {
                spriteSelect = 0;
            }
            yield return new WaitForSeconds(chatDelay);
        }
        spriteRenderer.sprite = userPics[spriteSelect];
        spriteSelect++;
        if( spriteSelect >= 4 ) {
            spriteSelect = 0;
        }
        if( historyNumber == 3 ) {
            spriteRenderer.enabled = false;
        }
    }

    void StopGame() {
        StopAllCoroutines();
    }
}
