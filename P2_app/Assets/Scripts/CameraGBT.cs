using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraGBT : MonoBehaviour
{
    private WebCamTexture camTexture;

    private void Start()
    {
        // Get the device's camera and display the feed on a texture
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            camTexture = new WebCamTexture(devices[0].name);
            GetComponent<Renderer>().material.mainTexture = camTexture;
            camTexture.Play();
        }
    }

    public void TakePhoto()
    {
        // Capture a screenshot of the camera feed
        Texture2D screenshot = new Texture2D(camTexture.width, camTexture.height);
        screenshot.ReadPixels(new Rect(0, 0, camTexture.width, camTexture.height), 0, 0);
        screenshot.Apply();

        // Save the screenshot as an image file
        byte[] bytes = screenshot.EncodeToPNG();
        string filename = "photo_" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
        File.WriteAllBytes(Application.persistentDataPath + "/" + filename, bytes);
    }
}
