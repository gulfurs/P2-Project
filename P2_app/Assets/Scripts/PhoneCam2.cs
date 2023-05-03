using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;


public class PhoneCam2 : MonoBehaviour
{
    WebCamTexture webCam;
    //string your_path = "C:\\alinajaseneckaja\\Desktop";// any path you want to save your image
    public RawImage display;
    public AspectRatioFitter fit;

    public void Start()
    {
        if (WebCamTexture.devices.Length == 0)
        {
            Debug.LogError("Can not find any camera!");
            return;
        }
        int index = -1;
        for (int i = 0; i < WebCamTexture.devices.Length; i++)
        {
            if (WebCamTexture.devices[i].name.ToLower().Contains("your webcam name"))
            {
                Debug.LogError("WebCam Name:" + WebCamTexture.devices[i].name + "   Webcam Index:" + i);
                index = i;
            }
        }

        if (index == -1)
        {
            Debug.LogError("Can not found your camera name!");
            return;
        }

        WebCamDevice device = WebCamTexture.devices[index];
        webCam = new WebCamTexture(device.name);
        webCam.Play();
        //StartCoroutine(TakePhoto());
        display.texture = webCam;

    }



    public void Update()
    {
        float ratio = (float)webCam.width / (float)webCam.height;
        fit.aspectRatio = ratio;


        float ScaleY = webCam.videoVerticallyMirrored ? -1f : 1f;
        display.rectTransform.localScale = new Vector3(1f, ScaleY, 1f);

        int orient = -webCam.videoRotationAngle;
        display.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

    }

    /* public void callTakePhoto() // call this function in button click event
    {
        StartCoroutine(TakePhoto());
    }

    IEnumerator TakePhoto()  // Start this Coroutine on some button click
    {

        // NOTE - you almost certainly have to do this here:

        yield return new WaitForEndOfFrame();

        // it's a rare case where the Unity doco is pretty clear,
        // http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
        // be sure to scroll down to the SECOND long example on that doco page 

        Texture2D photo = new Texture2D(webCam.width, webCam.height);
        photo.SetPixels(webCam.GetPixels());
        photo.Apply();

        //Encode to a PNG
        byte[] bytes = photo.EncodeToPNG();
        //Write out the PNG. Of course you have to substitute your_path for something sensible
        File.WriteAllBytes(your_path + "\\photo.png", bytes);

    } */
}