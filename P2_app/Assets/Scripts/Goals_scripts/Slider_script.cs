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
    public StepDetectorScript steps;
    private float sc;
    float goal = 50;

    private void Awake(){
        progressbar = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        Progress(50f);

    }

    void Update() {
        //sc = steps.stepCount * 0.1f;
        //progressbar.value = sc;
        Debug.Log(progressbar.value);
        if(progressbar.value < target){
            
            progressbar.value = steps.stepCount;
            
            //progressbar.value += 0.05f * (Time.deltaTime * FillSpeed);
        }else{
            done.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        
        
    }

    public void Progress(float newProgress){
        target = progressbar.value + newProgress;
    }

}
