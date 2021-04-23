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
        /*
        UserAImage = userA.GetMyImage();
        UserBImage = userB.GetMyImage();
        UserCImage = userC.GetMyImage();
        */
    }

    public int GetImageA()
    {
        return UserAImage;
    }

    public int GetImageB()
    {
        return UserBImage;
    }

    public int GetImageC()
    {
        return UserCImage;
    }

}
