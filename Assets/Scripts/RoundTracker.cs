using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundTracker : MonoBehaviour
{
    public int roundNumber;
    static RoundTracker trackerInstance;

    // Start is called before the first frame update
    void Start()
    {
        roundNumber = 1;
    }

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if( trackerInstance == null ) {
            trackerInstance = this;
        } else {
            Object.Destroy(this.gameObject);
        }
    }

    public int GetRoundNumber() {
        return roundNumber;
    }

    public void IncrementRound() {
        roundNumber++;
    }
}
