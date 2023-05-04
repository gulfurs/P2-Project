using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{
    private Slider progressbar;
    public GameObject done;
    private float target = 0;
    public float FillSpeed = 0.1f;
    //private bool filledup = false;

    private void Awake(){
        progressbar = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        Progress(1f);
       
    }

    void FixedUpdate()
    {
        if(progressbar.value < target){
            progressbar.value += 0.05f * (Time.deltaTime * FillSpeed);
        }else{
            //filledup = true;
            //if(filledup = true){
            done.SetActive(true);
            //Debug.Log("Done Button appears");
            //}
        }
        
    }

    public void Progress(float newProgress){
        target = progressbar.value + newProgress;
    }

}
