using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatboxPic : MonoBehaviour
{
    public int historyNumber;

    public Sprite[] userPics;
    SpriteRenderer spriteRenderer;

    int userASprite;
    int userBSprite;
    int userCSprite;

    float chatDelay;

    // Start is called before the first frame update
    void Awake()
    {
        chatDelay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown("2") ) {
            StartCoroutine(ScrollPic());
        }
    }

    IEnumerator ScrollPic() {
        foreach( Sprite s in userPics ) {
            spriteRenderer.sprite = s;
            yield return new WaitForSeconds(chatDelay);
        }
    }
}
