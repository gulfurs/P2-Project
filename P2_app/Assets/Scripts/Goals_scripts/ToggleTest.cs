using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ToggleTest : MonoBehaviour
{
    ToggleGroup Test;

// public Toggle current {
//         get {
//             return toggleGroupInstance.ActiveToggles ().FirstOrDefault (); 
//             }
//         }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(current.name);
        Test = GetComponent<ToggleGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    }

