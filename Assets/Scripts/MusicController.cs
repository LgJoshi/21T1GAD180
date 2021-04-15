using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    //Music list variable for controlling which AudioSource component to play when needed
    public AudioSource[] music;

    void OnEnable() {
        EventManager.StartEvent += PlayMusic;
        EventManager.EndEvent += StopMusic;
    }
    void OnDisable() {
        EventManager.StartEvent -= PlayMusic;
        EventManager.EndEvent -= StopMusic;
    }

    void PlayMusic() {
        StartCoroutine(PlayDelay());
    }

    IEnumerator PlayDelay() {
        yield return new WaitForSeconds(1.5f);
        music[0].Play();
    }

    void StopMusic() {
        music[0].Stop();
    }
}
