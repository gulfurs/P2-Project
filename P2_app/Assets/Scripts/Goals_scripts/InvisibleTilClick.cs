using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTilClick : MonoBehaviour
{

    public void Toggle(GameObject toggle)
    {
        toggle.SetActive(!toggle.activeSelf);
    }

    public void InvisibleToggle(GameObject toggle)
    {
        if(toggle.activeSelf == false) 
        {
            toggle.SetActive(toggle.activeSelf);
        }
    }
}
