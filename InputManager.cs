using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {


    CameraOrbit cam;


	// Use this for initialization
	void Start () {
        cam = GetComponent<CameraOrbit>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            // rotate the camera and take a screenshot
            cam.MoveHorizontal(true);
            ScreenshotHandler.TakeScreenshot_Static(1000, 1000);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            cam.MoveHorizontal(false);
            ScreenshotHandler.TakeScreenshot_Static(1000, 1000);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            cam.MoveVertical(true);
            // ScreenshotHandler.TakeScreenshot_Static(1000, 1000);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            cam.MoveVertical(false);
            // ScreenshotHandler.TakeScreenshot_Static(1000, 1000);
        }
    }
}
