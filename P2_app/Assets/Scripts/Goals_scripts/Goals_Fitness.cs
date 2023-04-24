using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goals_Fitness : MonoBehaviour
{
    public static Goals_Fitness goalsFitnessScene;

    public TMP_InputField inputField;

    public string challenge_name;

    private void Awake()
    {
       /* if (goalsFitnessScene == null)
        {
            goalsFitnessScene = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
        }*/
    }

    public void SetChallengeName()
    {
        challenge_name = inputField.text;
    }
}
