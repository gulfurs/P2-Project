using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Join_script : MonoBehaviour
{
   public TextMeshProUGUI Joincode;
    void Start()
    {
        int ranNum = Random.Range(1000,9999);
        Joincode.SetText(ranNum.ToString());
    }

 
}
