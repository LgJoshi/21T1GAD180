using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatboxPic : MonoBehaviour
{
    public int historyNumber;

    public Sprite[] userPics;
    SpriteRenderer spriteRenderer;

    float chatDelay;

    // Start is called before the first frame update
    void Awake()
    {
        chatDelay = 0.5;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        for( int i = 0;i < 3;i++ ) {
            Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayText() {
        foreach( Sprite s in userPics ) {
            spriteRenderer.sprite = s;
            yield return new WaitForSeconds(chatDelay);
        }
    }
}
