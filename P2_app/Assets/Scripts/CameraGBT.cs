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
   
}
