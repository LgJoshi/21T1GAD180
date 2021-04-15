using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    //Music list variable for controlling which AudioSource component to play when needed
    public AudioSource[] music;

    void OnEnable() {
        EventManager.StartEvent += PlayMusic;
        EventManager.TimeSpeedEvent += SpeedUp;
        EventManager.EndEvent += SlowDown;
    }
    void OnDisable() {
        EventManager.StartEvent -= PlayMusic;
        EventManager.TimeSpeedEvent -= SpeedUp;
        EventManager.EndEvent -= SlowDown;
    }

    void PlayMusic() {
        StartCoroutine(PlayDelay());
    }

    IEnumerator PlayDelay() {
        yield return new WaitForSeconds(1.5f);
        music[0].Play();
    }

    void SpeedUp() {
        music[0].pitch = 1.15f;
    }

    void SlowDown() {
        music[0].pitch = 0.8f;
    }

    void StopMusic() {
        music[0].Stop();
    }
}
