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
        //Canvas canvas = GameObject.FindGameObjectWithTag("GroupCanvas").GetComponent<Canvas>();
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
        }
    }

    void DeleteGroup(GameObject obj)
    {
        Destroy(obj);
    }

}
