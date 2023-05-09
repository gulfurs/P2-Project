using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Whole code from CHATGPT
public class StepDetectorScript : MonoBehaviour
{
    private float accelerationThreshold = 1.75f; // adjust this value as needed
    private bool stepDetected = false;
    public int stepCount = 0;
    [SerializeField] private TextMeshProUGUI tmp;

    void Update()
    {
        Vector3 acceleration = Input.acceleration;
        float accelerationMagnitude = acceleration.magnitude;

        if (accelerationMagnitude > accelerationThreshold && !stepDetected)
        {
            // Step detected
            stepDetected = true;
            stepCount++;
        }
        else if (accelerationMagnitude < accelerationThreshold && stepDetected)
        {
            // Step completed
            stepDetected = false;
        }
        tmp.text = stepCount.ToString();
        Debug.Log("Steps taken: + " + stepCount);
    }
}