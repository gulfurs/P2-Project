using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideCanvas : MonoBehaviour
{
    public string mainScene;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == mainScene)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
