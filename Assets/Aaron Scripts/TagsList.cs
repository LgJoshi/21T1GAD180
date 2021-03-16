using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagsList : MonoBehaviour
{
    public List<string> tags;
    string tagOne;
    string tagTwo;
    string tagThree;
    // Start is called before the first frame update
    void Awake()
    {
        tags = new List<string>();

        tags.Add("FPS");
        tags.Add("PvP");
        tags.Add("Action");
        tags.Add("Story Driven");
        tags.Add("Co-Op");
        tags.Add("Survival");
        tags.Add("Adventure");
        tags.Add("Crafting");
        tags.Add("Sandbox");
        tags.Add("Competitive");
  
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }

    //public List<string> userList = new List<string>();
}
