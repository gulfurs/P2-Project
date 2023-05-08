using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_photo : MonoBehaviour
{
   public void OnButtonClick()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        Debug.Log(Time.timeScale);
    }
}
