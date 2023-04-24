using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalManagement : MonoBehaviour
{
    public GameObject goalItem;
    public List<ItemManagement> goalItems;
    //public TextMeshProUGUI goalTitle;
    public float spacing = 50f;
    // Start is called before the first frame update



    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        IniitializeGoals();
    }

    public void IniitializeGoals()
	{
        Canvas canvas = GameObject.FindGameObjectWithTag("GoalCanvas").GetComponent<Canvas>();

        GameObject[] prevGoalItems = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject prevGoalItem in prevGoalItems)
        {
            Destroy(prevGoalItem);
        }

        for (int i = 0; i <= goalItems.Count - 1; i++)
        {
            GameObject goalObject = Instantiate(goalItem, canvas.transform);
            goalObject.tag = "Item";
            goalObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * spacing);
            goalObject.GetComponent<Image>().color = goalItems[i].groupColor;
            goalObject.GetComponentInChildren<TextMeshProUGUI>().text = goalItems[i].groupName;
        }
    }
}

