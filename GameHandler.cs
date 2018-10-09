using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // Use Spacebar key to take a screenshot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScreenshotHandler.TakeScreenshot_Static(1000, 1000);
        }
		
	}
}
