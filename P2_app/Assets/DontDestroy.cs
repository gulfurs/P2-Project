using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class DontDestroy : MonoBehaviour
{
    public string objectID;
    public string mainScene;
    public Canvas canvas;

    private void Awake()
    {
        objectID = name;    //ID is assigned the name of the object
    }
    


	void Start()
	{
        //Iterates through all the different objects with the DontDestroy class and 
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
		{
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
			{
                if (Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
				{
                    Destroy(gameObject);
                    Debug.Log(Object.FindObjectsOfType<DontDestroy>().Length);
				}
			}
		}
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        //Disable the canvas if it isn't the right scene
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
