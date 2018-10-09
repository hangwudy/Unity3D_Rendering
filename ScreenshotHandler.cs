using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour {

    private static ScreenshotHandler instance;

    private bool takeScreenshotOnNextFrame;

    private Camera myCamera;

    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takeScreenshotOnNextFrame)
        {
            takeScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;

            Texture2D renderResult = new Texture2D(renderTexture.width,
                renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            var date = DateTime.Now;

            // name format: yyyymmddhhmmssmsmsms
            System.IO.File.WriteAllBytes(Application.dataPath + "/Screenshots/car_door_"+
                date.Year + date.Month + date.Day + date.Hour + date.Minute +
                date.Second + date.Millisecond + ".png", byteArray);
            // Debug.Log(myCamera.transform.rotation);
            Debug.Log(myCamera.transform.eulerAngles.y);
            int y_axis_angle = Convert.ToInt32(myCamera.transform.eulerAngles.y);
            Debug.Log(y_axis_angle);

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
        }
    }

    private void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 3);
        takeScreenshotOnNextFrame = true;
    }

    public static void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);
    }
}
