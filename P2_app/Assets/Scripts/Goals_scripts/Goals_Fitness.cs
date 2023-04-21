using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goals_Fitness : MonoBehaviour
{
    public static Goals_Fitness goalsFitnessScene;

    public TMP_InputField inputField;

    public string challenge_name;
    //public bool done;

    private void Awake()
    {
        if (goalsFitnessScene == null)
        {
            goalsFitnessScene = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetObjectActive (bool isActive){
        gameObject.SetActive(isActive);
       // done = true;
    }

    public void SetChallengeName()
    {
        challenge_name = inputField.text;
    }
}
