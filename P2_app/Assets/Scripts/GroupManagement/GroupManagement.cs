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
        Canvas canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        for (int i = 0; i <= GroupItems.Count-1; i++)
        {
                GameObject groupObject = Instantiate(groupItem, canvas.transform);

                groupObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, i * spacing);
                groupObject.GetComponent<Image>().color = GroupItems[i].groupColor;
                groupObject.GetComponentInChildren<Text>().text = GroupItems[i].groupName;
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToGroup() {
        groupTab.SetActive(true);
        Debug.Log("Initializing Change to Group");
    }
}
