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
    public float spacing = 50f;
    public GameObject groupTab;
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

        GameObject[] prevGroupItems = GameObject.FindGameObjectsWithTag("GroupItem");
        foreach (GameObject prevGroupItem in prevGroupItems)
        {
            Destroy(prevGroupItem);
        }

        for (int i = 0; i <= GroupItems.Count - 1; i++)
        {
            GameObject groupObject = Instantiate(groupItem, canvas.transform);
            groupObject.tag = "GroupItem";
            groupObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * spacing);
            groupObject.GetComponent<Image>().color = GroupItems[i].groupColor;
            groupObject.GetComponentInChildren<Text>().text = GroupItems[i].groupName;

        }
    }

    public void ChangeToGroup() {
        groupTab.SetActive(true);
        Debug.Log("Initializing Change to Group");
    }
}
