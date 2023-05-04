using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slider_script : MonoBehaviour
{
    private Slider progressbar;
    private float target = 0;
    public float FillSpeed = 100000.1f;

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
            progressbar.value += 0.01f * (Time.deltaTime * FillSpeed);
            Debug.Log(Time.deltaTime * FillSpeed);
        }
    }

    public void Progress(float newProgress){
        target = progressbar.value + newProgress;
    }

}
