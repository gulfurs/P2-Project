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
        //prevGoalItems = GameObject.FindGameObjectsWithTag("Item");
    }

    public void InitializeGoals()
    {
        Canvas canvas = GameObject.FindGameObjectWithTag("GoalCanvas").GetComponent<Canvas>();

        for (int i = parentingTab.transform.childCount - 1; i >= 0; i--)
        {
            // Destroy each child object
            Destroy(parentingTab.transform.GetChild(i).gameObject);
        }

        for (int i = 0; i <= goalItems.Count - 1; i++)
        {
            GameObject goalObject = Instantiate(goalItem, parentingTab.transform);
            goalObject.name = goalItems[i].groupName;
            goalObject.tag = "Item";
            goalObject.GetComponent<Image>().color = goalItems[i].groupColor;
            goalObject.GetComponentInChildren<TextMeshProUGUI>().text = goalItems[i].groupName;
        }

        
    }

    IEnumerator InitGoals() {
        //IniitializeGoals();
        yield return null;
    }
}

