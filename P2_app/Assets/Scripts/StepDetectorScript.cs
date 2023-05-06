using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Whole code from CHATGPT
public class StepDetectorScript : MonoBehaviour
{
    private float accelerationThreshold = 1.2f; // adjust this value as needed
    private bool stepDetected = false;
    private int stepCount = 0;

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

        Debug.Log("Steps taken: + " + stepCount);
    }
}