using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPanelActive : MonoBehaviour
{
	public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        SetToActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	public void SetToActive()
	{
		canvas.gameObject.SetActive(true);
	}
}
