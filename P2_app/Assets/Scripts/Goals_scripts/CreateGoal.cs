using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateGoal : MonoBehaviour
{
    
    [SerializeField] private Sprite Fill;
    [SerializeField] private Sprite NoFill;

    private Button choiceButton; 
    //private bool isOn = true;

    //public Sprite Fill;
    //public Sprite Nofill;

    void Awake()
    {
        choiceButton.image.sprite = NoFill;
        choiceButton = GetComponent<Button>();
        choiceButton.onClick.AddListener(OnClick);
    }

    void OnClick(){
        if (choiceButton == null) return;
        //isOn = !isOn;
        //choiceButton.image.sprite = isOn ? NoFill : Fill;
        choiceButton.image.sprite = Fill;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
