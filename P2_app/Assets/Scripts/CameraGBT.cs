using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class CameraGBT : MonoBehaviour
{
    private WebCamTexture camTexture;
    private RawImage img;
    private bool isPaused = false;

    private void Start()
    {
        // Get the device's camera and display the feed on a texture
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            camTexture = new WebCamTexture(devices[0].name);
            //GetComponent<Renderer>().material.mainTexture = camTexture;
            camTexture.Play();
        }
        img = GetComponent<RawImage>();
        img.texture = camTexture;
        img.material = null;
    }


    private void FixedUpdate()
    {
        if (Time.timeScale == 0f && !isPaused)
        {
            camTexture.Stop();
            isPaused = true;
            
        }
        else if (Time.timeScale != 0f && isPaused)
        {
            camTexture.Play();
            isPaused = false;
        }
    }
    // public void TakePhoto()
    // { 
    //     Texture2D screenshot = new Texture2D(camTexture.width, camTexture.height);
    //     screenshot.ReadPixels(new Rect(0, 0, camTexture.width, camTexture.height), 0, 0);
    //     screenshot.Apply();

    //     // Capture a screenshot of the camera feed
       
    //     // Save the screenshot as an image file
    //     byte[] bytes = screenshot.EncodeToPNG();
    //     string filename = "photo_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
    //     File.WriteAllBytes(Application.persistentDataPath + "/" + filename, bytes);
    // }
}
