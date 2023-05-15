using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{
   
    public GameObject done;
    private float target = 0;
    public float FillSpeed = 0.1f;
    //private bool filledup = false;
    public StepDetectorScript steps;
    private Slider progressbar;

    private void Awake(){
        progressbar = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        Progress(20f);
    }

    void Update()
    {
        if(progressbar.value < target){
            progressbar.value = steps.stepCount;
        }else{
            done.SetActive(true);
        }   
    }
    public void Progress(float newProgress){
        target = progressbar.value + newProgress;
    }
}
