using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UIElements;

public class Achiement : MonoBehaviour
{
    public GameObject Panel;
    public GameObject HideButton;
    

    public void ShowPanel()
    {
        Panel.SetActive(true);
        
    }

    public void HidePanel()
    {
        Panel.SetActive(false);
       
    }
}

