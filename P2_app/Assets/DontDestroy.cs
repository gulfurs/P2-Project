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
        objectID = name + transform.position.ToString();
        //DebugManager.instance.enableRuntimeUI = false;
    }
    


	void Start()
	{
        //canvas.enabled = false;

        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
		{
            if (Object.FindObjectsOfType<DontDestroy>()[i] != this)
			{
                if (Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
				{
                    Destroy(gameObject);
                    Debug.Log("Destroying: " + gameObject);
				}
			}
		}
        DontDestroyOnLoad(gameObject);
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
