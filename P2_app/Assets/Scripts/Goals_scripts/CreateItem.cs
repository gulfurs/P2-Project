using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private ItemManagement itemTemp;  //ItemManagement object that the rest should follow
    public GameObject checkInput;   //InputFieldfield
    public GameObject doneButton;   //Button that is marked as done

    public GameObject goalManagement;   //Goalmanagement object
    public GameObject groupManagement;   //Goalmanagement object

    public List<ItemManagement> listOfGoals;    //List of ItemManagement objects

    // Start is called before the first frame update
    void Start()
    {
        //Picks up the goalItems list from the not destroyed GoalCanvas
        goalManagement = GameObject.Find("GoalManagement") as GameObject;
        groupManagement = GameObject.Find("GroupManagement") as GameObject;
        listOfGoals = goalManagement.GetComponent<GoalManagement>().goalItems;
    }

    // Update is called once per frame
    void Update()
    {
        //If there is no text in the input field will you not be able to click the doneButton
        string inputText = checkInput.GetComponent<TMPro.TMP_InputField>().text;
        doneButton.GetComponent<Button>().interactable = !string.IsNullOrEmpty(inputText);
    }

    //Creates a new Goal/GroupItem Item from buttonPress
    public void CreatingItem(GameObject groupInput)
    {
        //Get text from input field
        string nameInput = groupInput.GetComponent<TMPro.TMP_InputField>().text;

        //Instantiates a newItem
        var newItem = Instantiate(itemTemp);

        //Set values on the item
        newItem.groupName = nameInput;
        newItem.groupColor = new Color(1f, 0.549f, 0.353f);

        //Updates the lists
        listOfGoals.Add(newItem);
        goalManagement.GetComponent<GoalManagement>().goalItems = listOfGoals;
        groupManagement.GetComponent<GroupManagement>().GroupItems.Add(newItem);


        //Update the goal items (visually)
        goalManagement.GetComponent<GoalManagement>().InitializeGoals();
        groupManagement.GetComponent<GroupManagement>().InitGroups();


    }
}
