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

    void OnEnable() {
        EventManager.OptionEvent += ChatPicScroll;
    }
    void OnDisable() {
        EventManager.OptionEvent -= ChatPicScroll;
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
}

    void Update()
    {
        if( Input.GetKeyDown("2") ) {
            spriteSelect = historyNumber;
            StartCoroutine(ScrollPic());
        }
    }

    void ChatPicScroll() {
        spriteSelect = historyNumber;
        StartCoroutine(ScrollPic());
    }

    IEnumerator ScrollPic() {

        //if this is changed, make sure it matches chatboxchat and playeroptions
        yield return new WaitForSeconds(2);

        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
        }
        
        for( int i = 0;i < 4;i++ ) {
            spriteRenderer.sprite = userPics[spriteSelect];
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
}
