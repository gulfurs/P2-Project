using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleTilClick : MonoBehaviour
{

    public void Toggle(GameObject toggle)
    {
        toggle.SetActive(!toggle.activeSelf);
    }

}
