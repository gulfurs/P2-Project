using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupManagement : MonoBehaviour
{
    public GameObject groupItem;
    public List<ItemManagement> GroupItems;
    public GameObject CousinItems;
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
            ItemManagement getItem = groupObject.GetComponent<StoreData>().itemData;
            getItem = GroupItems[i];
            groupObject.name = getItem.groupName;
            groupObject.GetComponent<Image>().color = getItem.groupColor;
            groupObject.GetComponentInChildren<TextMeshProUGUI>().text = getItem.groupName;
            Transform imageOfGroup = groupObject.transform.Find("GroupPhoto");
            imageOfGroup.GetComponent<Image>().sprite = getItem.groupPhoto;
            
            //Gameobject path
            string objectPath = "LeaderboardCanvas/LeaderTab/ScrollGroup/MyGroup/";

            //Title of the group
            Transform titleOfGroup = groupObject.transform.Find(objectPath + "UpperTab/GroupTitle");
            titleOfGroup.GetComponent<TextMeshProUGUI>().text = getItem.groupName;

            //Delete Button is instantiated here using the template
            GameObject delbutton = Instantiate(deleteButton, groupObject.transform.Find(objectPath + "LowerTab/DeleteGroup"));
            delbutton.transform.localPosition = new Vector3(0, 0, 0);
            delbutton.name = "DeleteButton";
            delbutton.GetComponent<Button>().onClick.AddListener(() => DeleteGroup(groupObject));
            
            //Color theme is covered here
            Transform upperTab = groupObject.transform.Find(objectPath + "UpperTab");
            upperTab.GetComponent<Image>().color = getItem.groupColor;
            Transform lowerTab = groupObject.transform.Find(objectPath + "LowerTab");
            lowerTab.GetComponent<Image>().color = getItem.groupColor;

            //Changes the group description.
            Transform DescOfGroup = groupObject.transform.Find(objectPath + "UpperTab/Description");
            DescOfGroup.GetComponent<TextMeshProUGUI>().text = getItem.groupDescription;

            //Initializes the leaderboard
            Transform rankingOfGroup = groupObject.transform.Find(objectPath + "Ranks");
            

            UpdateChallengerData(rankingOfGroup, getItem.groupChallengers, getItem.groupStats, getItem.groupColor);

            switch (getItem.groupStatus)
            {
                case GroupStatus.Member:
                    //Manage DeleteButton
                    MemberRights(delbutton);
                    break;
                case GroupStatus.Uninvited:
                    Transform joinButton = groupObject.transform.Find(objectPath + "UpperTab/Code/HideCode");
                    UninvitedRights(delbutton, joinButton);
                    joinButton.GetComponent<Button>().onClick.AddListener(() => Add2myGroups(groupObject, getItem, delbutton));

                    break;
                case GroupStatus.Admin:
                    //Manage DeleteButton
                    AdminRights(delbutton);
                    break;
            }
        }
    }

    void DeleteGroup(GameObject obj)
    {
        //GroupItems.Remove(obj.name);
        Destroy(obj);
    }


    void Add2myGroups(GameObject obj, ItemManagement item, GameObject del)
    {
        obj.transform.SetParent(null);
        obj.transform.SetParent(CousinItems.transform);
        item.groupStatus = GroupStatus.Member;

        // Add a new element to groupChallengers
        string[] newChallengers = new string[item.groupChallengers.Length + 1];
        for (int i = 0; i < item.groupChallengers.Length; i++)
        {
            newChallengers[i] = item.groupChallengers[i];
        }
        newChallengers[newChallengers.Length - 1] = "Camilla Jensen (You)";
        item.groupChallengers = newChallengers;

        // Add a new element to groupStats
        string[] newStats = new string[item.groupStats.Length + 1];
        for (int i = 0; i < item.groupStats.Length; i++)
        {
            newStats[i] = item.groupStats[i];
        }
        newStats[newStats.Length - 1] = "0";
        item.groupStats = newStats;
        MemberRights(del);
        //UpdateChallengerData(obj.transform.Find("LeaderboardCanvas/LeaderTab/ScrollGroup/MyGroup/" + "Ranks"), item.groupChallengers, item.groupStats, item.groupColor);
    }

    void AdminRights(GameObject del) {
        del.GetComponentInChildren<TextMeshProUGUI>().text = "Delete Group";
    }

    void MemberRights(GameObject del) {
        del.GetComponentInChildren<TextMeshProUGUI>().text = "Leave Group";
    }

    void UninvitedRights(GameObject del, Transform join) {
        //Manage DeleteButton
        del.transform.parent.gameObject.SetActive(false);
        join.GetComponentInChildren<TextMeshProUGUI>().text = "Join Group";
    }

    public void UpdateChallengerData(Transform obj, string[] names, string[] stats, Color color)
    {
        TextMeshProUGUI[] challengers = obj.GetComponentsInChildren<TextMeshProUGUI>();
        List<TextMeshProUGUI> namesOfChallengers = new List<TextMeshProUGUI>();
        List<TextMeshProUGUI> statsOfChallengers = new List<TextMeshProUGUI>();

        // Adds text Names to a list
        for (int j = 0; j < challengers.Length; j++)
        {
            if (challengers[j].text.StartsWith("Name:"))
            {
                namesOfChallengers.Add(challengers[j]);
            }
        }

        // Adds text Stats to a list
        for (int j = 0; j < challengers.Length; j++)
        {
            if (challengers[j].text.StartsWith("xxx"))
            {
                statsOfChallengers.Add(challengers[j]);
            }
        }

        // Replaces the Name: with challenger names in the group Item
        for (int j = 0; j < namesOfChallengers.Count && j < names.Length && j < stats.Length; j++)
        {
            namesOfChallengers[j].text = names[j];
            statsOfChallengers[j].text = stats[j];

            if (namesOfChallengers[j].text.EndsWith("(You)"))
            {
                namesOfChallengers[j].color = color;
            }
        }

        // Makes a final sweep to deactivate all parent objects without a proper name
        foreach (var checkForName in challengers)
        {
            if (checkForName.text.StartsWith("Name:"))
            {
                checkForName.text = null;
                //checkForName.transform.parent.gameObject.SetActive(false);
            }
            else if (checkForName.text.StartsWith("xxx"))
            {
                checkForName.text = null;
                //checkForName.transform.parent.gameObject.SetActive(false);
            }
        }
    }

}
