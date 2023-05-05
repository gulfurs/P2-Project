using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupManagement : MonoBehaviour
{
    public GameObject groupItem;
    public List<ItemManagement> GroupItems;
    public TextMeshProUGUI groupTitle;
    public GameObject parentTab;
    //public Sprite deleteButtonSprite;
    public GameObject deleteButton;
    // Start is called before the first frame update
    //public string = 


    void Start()
    {
       InitGroups();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitGroups()
	{
        Canvas canvas = GameObject.FindGameObjectWithTag("GroupCanvas").GetComponent<Canvas>();
        /*
        GameObject[] prevGroupItems = GameObject.FindGameObjectsWithTag("GroupItem");
        foreach (GameObject prevGroupItem in prevGroupItems)
        {
            Destroy(prevGroupItem);
        }*/

        for (int i = 0; i <= GroupItems.Count - 1; i++)
        {
            GameObject groupObject = Instantiate(groupItem, parentTab.transform);
            groupObject.tag = "GroupItem";
            groupObject.name = "GroupItem " + i;
            groupObject.GetComponent<Image>().color = GroupItems[i].groupColor;
            groupObject.GetComponentInChildren<TextMeshProUGUI>().text = GroupItems[i].groupName;
            Transform imageOfGroup = groupObject.transform.Find("GroupPhoto");
            imageOfGroup.GetComponent<Image>().sprite = GroupItems[i].groupPhoto;
            
            //Gameobject path
            string objectPath = "LeaderboardCanvas/LeaderTab/ScrollGroup/MyGroup/";

            //Title of the group
            Transform titleOfGroup = groupObject.transform.Find(objectPath + "UpperTab/GroupTitle");
            titleOfGroup.GetComponent<TextMeshProUGUI>().text = GroupItems[i].groupName;

            //Delete Button is instantiated here using the template
            GameObject delbutton = Instantiate(this.deleteButton, groupObject.transform);
            delbutton.transform.SetParent(groupObject.transform.Find(objectPath + "LowerTab"), false);
            delbutton.name = "DeleteButton";
            delbutton.GetComponent<Button>().onClick.AddListener(() => DeleteGroup(groupObject));
            
            //Color theme is covered here
            Transform upperTab = groupObject.transform.Find(objectPath + "UpperTab");
            upperTab.GetComponent<Image>().color = GroupItems[i].groupColor;
            Transform lowerTab = groupObject.transform.Find(objectPath + "LowerTab");
            lowerTab.GetComponent<Image>().color = GroupItems[i].groupColor;

            //Changes the group description.
            Transform DescOfGroup = groupObject.transform.Find(objectPath + "UpperTab/Description");
            DescOfGroup.GetComponent<TextMeshProUGUI>().text = GroupItems[i].groupDescription;

            //Initializes the leaderboard
            Transform rankingOfGroup = groupObject.transform.Find(objectPath + "Ranks");
            TextMeshProUGUI[] challengers = rankingOfGroup.GetComponentsInChildren<TextMeshProUGUI>();
            List<TextMeshProUGUI> namesOfChallengers = new List<TextMeshProUGUI>();
            List<TextMeshProUGUI> statsOfChallengers = new List<TextMeshProUGUI>();

            //Adds text Names to a list
            for (int j = 0; j < challengers.Length; j++)
            {
                if (challengers[j].text.StartsWith("Name:"))
                {
                    namesOfChallengers.Add(challengers[j]);
                }
            }

            //Adds text Stats to a list
            for (int j = 0; j < challengers.Length; j++)
            {
                if (challengers[j].text.StartsWith("xxx"))
                {
                    statsOfChallengers.Add(challengers[j]);
                }
            }

            //Replaces the Name: with challenger names in the group Item
            for (int j = 0; j < namesOfChallengers.Count && j < GroupItems[i].groupChallengers.Length; j++)
            {
                    namesOfChallengers[j].text = GroupItems[i].groupChallengers[j];
                    statsOfChallengers[j].text = GroupItems[i].groupStats[j];
                    if (namesOfChallengers[j].text.EndsWith("(You)")) {
                    namesOfChallengers[j].color = GroupItems[i].groupColor;
                    }
            }

            //Makes a final sweep to deactivate all parent objects without a proper name
            foreach (var checkForName in challengers)
            {
                if (checkForName.text.StartsWith("Name:"))
                {
                    checkForName.text = null;
                    //checkForName.transform.parent.gameObject.SetActive(false);
                } else if (checkForName.text.StartsWith("xxx"))
                {
                    checkForName.text = null;
                    //checkForName.transform.parent.gameObject.SetActive(false);
                }
            }


        }
    }

    void DeleteGroup(GameObject obj)
    {
        Destroy(obj);
    }

}
