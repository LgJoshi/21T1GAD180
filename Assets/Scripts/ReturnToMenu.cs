﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MusicEnd() {
        GameObject.Find("MusicMaster").GetComponent<MusicController>().StopMusic();
    }

    public void ReturnToMainScene()
	{
		SceneManager.LoadScene(sceneName:"Menu");
	}
}
