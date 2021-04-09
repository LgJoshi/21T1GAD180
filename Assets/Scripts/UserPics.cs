using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserPics : MonoBehaviour
{
    public UserA userA;
    public UserB userB;
    public UserC userC;

    public int UserAImage;
    public int UserBImage;
    public int UserCImage;

    void Start()
    {
        UserAImage = userA.GetMyImage();
        UserBImage = userB.GetMyImage();
        UserCImage = userC.GetMyImage();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public int GetImages()
    {
        return UserAImage;
        return UserBImage;
        return UserCImage;
    }

}
