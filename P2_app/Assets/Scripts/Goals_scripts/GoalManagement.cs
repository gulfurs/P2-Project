using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoalManagement : MonoBehaviour
{
    public GameObject goalItem; //Template that the goals have to folllow
    public List<ItemManagement> goalItems;  //List of each different item
    public GameObject parentingTab; //Parentobject to throw the goals under (Vertical Layout Group helps organize it)
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(InitGoals());
        InitializeGoals();
    }

    //Goals from the list are created
    public void InitializeGoals()
    {
        //Destroy each child object under the parentingTab (To avoid duplicates)
        for (int i = parentingTab.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(parentingTab.transform.GetChild(i).gameObject);
        }

        //Instantiate each goalItem in the list under the parentingtab, and replaces details in the template.
        for (int i = 0; i <= goalItems.Count - 1; i++)
        {
            GameObject goalObject = Instantiate(goalItem, parentingTab.transform);
            goalObject.name = goalItems[i].groupName;
            goalObject.tag = "Item";
            goalObject.GetComponent<Image>().color = goalItems[i].groupColor;
            goalObject.GetComponentInChildren<TextMeshProUGUI>().text = goalItems[i].groupName;
        }

        
    }
}

