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
        //Canvas canvas = GameObject.FindGameObjectWithTag("GroupCanvas").GetComponent<Canvas>();

        GameObject[] prevGroupItems = GameObject.FindGameObjectsWithTag("GroupItem");
        foreach (GameObject prevGroupItem in prevGroupItems)
        {
            Destroy(prevGroupItem);
        }

        for (int i = 0; i <= GroupItems.Count - 1; i++)
        {
            GameObject groupObject = Instantiate(groupItem, parentTab.transform);
            groupObject.tag = "GroupItem";
            groupObject.GetComponent<Image>().color = GroupItems[i].groupColor;
            groupObject.GetComponentInChildren<TextMeshProUGUI>().text = GroupItems[i].groupName;
            
            
            Transform leaderboardCanvas = groupObject.transform.Find("LeaderboardCanvas/LeaderTab");
            leaderboardCanvas.GetComponentInChildren<TextMeshProUGUI>(true).text = GroupItems[i].groupName;
            leaderboardCanvas.GetComponentInChildren<Image>(true).color = GroupItems[i].groupColor;

            Transform groupDesc = groupObject.transform.Find("LeaderboardCanvas/LeaderTab/UpperTab/Description");
            groupDesc.GetComponent<TextMeshProUGUI>().text = GroupItems[i].groupDescription;
        }
    }
    
}
