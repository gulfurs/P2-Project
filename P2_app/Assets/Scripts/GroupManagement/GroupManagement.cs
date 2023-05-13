using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GroupManagement : MonoBehaviour
{
    public GameObject groupItem;    //GroupItem template
    public List<ItemManagement> GroupItems; //List of ItemManagement objects

    public GameObject parentTab;    //Parent Tab for my groups
    public GameObject uncleTab;     //Parent Tab for reccomended groups (Neglected)

    public GameObject deleteButton;     //Delete button

    List<TextMeshProUGUI> namesOfChallengers;   //List for names
    List<TextMeshProUGUI> statsOfChallengers;   //List for stats

    // Start is called before the first frame update
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

        // Destroy each child object in the parenttab
        for (int i = parentTab.transform.childCount - 1; i >= 0; i--)
        {
           
            Destroy(parentTab.transform.GetChild(i).gameObject);
        }

        // Destroy each child object in the uncleTab
        for (int i = uncleTab.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(uncleTab.transform.GetChild(i).gameObject);
        }

        //Creates all the groupObject, names them, colors them and more.
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
            
            //Updates leaderboard for each group
            UpdateChallengerData(rankingOfGroup, getItem.groupChallengers, getItem.groupStats, getItem.groupColor);

            //What status is the group?
            switch (getItem.groupStatus)
            {
                case GroupStatus.Member:
                    //Manage DeleteButton
                    groupObject.transform.SetParent(parentTab.transform);
                    MemberRights(delbutton);
                    break;
                case GroupStatus.Uninvited:
                    //groupObject.transform.SetParent(uncleTab.transform);
                    Transform joinButton = groupObject.transform.Find(objectPath + "UpperTab/Code/HideCode");
                    UninvitedRights(delbutton, joinButton);
                    joinButton.GetComponent<Button>().onClick.AddListener(() => Add2myGroups(groupObject, getItem, delbutton));

                    break;
                case GroupStatus.Admin:
                    //Manage DeleteButton
                    groupObject.transform.SetParent(parentTab.transform);
                    AdminRights(delbutton);
                    break;
            }
        }
    }

    //Deletes the current group
    void DeleteGroup(GameObject obj)
    {
        //GroupItems.Remove(obj);
        Destroy(obj);
        //InitGroups();
    }

    // Add new elements to leaderboard(For when you join)
    void Add2myGroups(GameObject obj, ItemManagement item, GameObject del)
    {
        item.groupStatus = GroupStatus.Member;

        string[] newChallengers = new string[item.groupChallengers.Length + 1];
        for (int i = 0; i < item.groupChallengers.Length; i++)
        {
            newChallengers[i] = item.groupChallengers[i];
        }
        newChallengers[newChallengers.Length - 1] = "Camilla Jensen (You)";
        item.groupChallengers = newChallengers;
        InitGroups();
    }

    //If user is a administrator of the group
    void AdminRights(GameObject del) {
        del.GetComponentInChildren<TextMeshProUGUI>().text = "Delete Group";
    }

    //If user is a member of the group
    void MemberRights(GameObject del) {
        del.GetComponentInChildren<TextMeshProUGUI>().text = "Leave Group";
    }

    //If user is not yet a member of the group(Neglected)
    void UninvitedRights(GameObject del, Transform join) {
        del.transform.parent.gameObject.SetActive(false);
        join.GetComponentInChildren<TextMeshProUGUI>().text = "Join Group";
    }

    //Updates leaderboard with names and stats
    public void UpdateChallengerData(Transform obj, string[] names, string[] stats, Color color)
    {
        TextMeshProUGUI[] challengers = obj.GetComponentsInChildren<TextMeshProUGUI>();
        namesOfChallengers = new List<TextMeshProUGUI>();
        statsOfChallengers = new List<TextMeshProUGUI>();

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
            }
            else if (checkForName.text.StartsWith("xxx"))
            {
                checkForName.text = null;
            }
        }
    }

}
