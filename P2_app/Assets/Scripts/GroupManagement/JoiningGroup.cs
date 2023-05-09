using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoiningGroup : MonoBehaviour
{
    public GameObject groupManager;
    public ItemManagement joinItem;
    public string roomCode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void JoinGroup(TMPro.TMP_InputField userInput)
    {
        if (userInput.text == roomCode)
        {
            groupManager.GetComponent<GroupManagement>().GroupItems.Add(joinItem);
            groupManager.GetComponent<GroupManagement>().InitGroups();

        }
    }
}
