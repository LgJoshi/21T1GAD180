using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatboxPic : MonoBehaviour
{
    public int historyNumber;
    int spriteSelect;

    public Sprite[] userPics;
    SpriteRenderer spriteRenderer;

    /*
    int userASprite;
    int userBSprite;
    int userCSprite;
    */

    float timeSpan;
    float chatDelay;

    void OnEnable() {
        EventManager.OptionEvent += ChatPicScroll;
    }
    void OnDisable() {
        EventManager.OptionEvent -= ChatPicScroll;
    }

    // Start is called before the first frame update
    void Awake()
    {
        timeSpan = 4;
        chatDelay = timeSpan/4;
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
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

        yield return new WaitForSeconds(2);

        if( historyNumber == 3 ) {
            spriteRenderer.enabled = true;
        }

        int i = 0;
        while( i<4 ) {
            i++;
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
