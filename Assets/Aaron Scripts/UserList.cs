using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserList : MonoBehaviour
{
    public GameObject userPrefab;
    public List<User> onlineUsers;

    void Start()
    {
        onlineUsers = new List<User>();

        for(int i = 0; i <= 2; i++)
        {
            GameObject newUser = Instantiate(userPrefab, this.transform.position + new Vector3(Random.Range(0, 11.1f), Random.Range(0, 11.1f), Random.Range(0, 11.1f)), this.transform.rotation);

        }
    }

}
