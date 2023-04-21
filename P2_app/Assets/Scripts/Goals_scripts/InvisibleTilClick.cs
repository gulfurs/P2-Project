using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTilClick : MonoBehaviour
{
    
    // public static bool Showhidden = false;
    // public GameObject Hid;
    // public static InvisibleTilClick GameInstance;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void Toggle(GameObject toggle)
    {
        toggle.SetActive(!toggle.activeSelf);
    }

}
