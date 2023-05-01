using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class GoalManagement : MonoBehaviour
{
    public GameObject goalItem;
    public List<ItemManagement> goalItems;
    //public TextMeshProUGUI goalTitle;
    public GameObject parentingTab;
    public GameObject[] prevGoalItems;
    // Start is called before the first frame update



    void Start()
    {
        //StartCoroutine(InitGoals());
        InitializeGoals();
    }

    // Update is called once per frame
    void Update()
    {
        prevGoalItems = GameObject.FindGameObjectsWithTag("Item");
    }

    public void InitializeGoals()
    {
        Canvas canvas = GameObject.FindGameObjectWithTag("GoalCanvas").GetComponent<Canvas>();


        for (int i = 0; i <= goalItems.Count - 1; i++)
        {
            GameObject goalObject = Instantiate(goalItem, parentingTab.transform);
            goalObject.tag = "Item";
            goalObject.GetComponent<Image>().color = goalItems[i].groupColor;
            goalObject.GetComponentInChildren<TextMeshProUGUI>().text = goalItems[i].groupName;
            GameObject existingObject = GameObject.FindGameObjectWithTag("Item");
            if (existingObject != null && existingObject.GetComponentInChildren<TextMeshProUGUI>().text == goalItems[i].groupName)
            {
                Destroy(existingObject);
            }

        }

        
    }

    IEnumerator InitGoals() {
        //IniitializeGoals();
        yield return null;
    }
}

