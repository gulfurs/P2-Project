using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class CreateItem : MonoBehaviour
{
    [SerializeField] private ItemManagement itemTemp;
    public GameObject checkInput;
    public GameObject doneButton;

    [HideInInspector]
    public GameObject goalManagement;

    public List<ItemManagement> listOfGoals;

    // Start is called before the first frame update
    void Start()
    {
        goalManagement = GameObject.FindGameObjectWithTag("EditorOnly");
        if (goalManagement != null)
        {
            //listOfGoals = goalManagement;
            listOfGoals = goalManagement.GetComponent<GoalManagement>().goalItems;
        }
    }

    // Update is called once per frame
    void Update()
    {
        string inputText = checkInput.GetComponent<TMPro.TMP_InputField>().text;
        bool isDuplicate = false;
        var items = AssetDatabase.FindAssets("t:ItemManagement", new[]{ "Assets/Groupitems" }); //Find all items that are labeled in Item Management in the folder GroupItems
        foreach (var GUID in items)
        {
            var path = AssetDatabase.GUIDToAssetPath(GUID); //returns the file path for the scriptable object based on its ID
            var asset = AssetDatabase.LoadAssetAtPath<ItemManagement>(path); //Loads the asset and it's components with the help from a located path
            if (string.Equals(asset.groupName, inputText, StringComparison.OrdinalIgnoreCase))
            {
                isDuplicate = true;
                break;
            }
        }
        doneButton.GetComponent<Button>().interactable = !string.IsNullOrEmpty(inputText) && !isDuplicate;
    }

    public void CreatingItem(GameObject groupInput)
    {
        string nameInput = groupInput.GetComponent<TMPro.TMP_InputField>().text;
        string filepath = "Assets/Groupitems/" + nameInput + ".asset";
        // Create a new instance of the ScriptableObject
        var newItem = Instantiate(itemTemp);

        // Set values on the item
        newItem.groupPhoto = null;
        newItem.groupName = nameInput;
        newItem.groupColor = new Color(1f, 0.549f, 0.353f);

        listOfGoals.Add(newItem);
        goalManagement.GetComponent<GoalManagement>().goalItems = listOfGoals;

        // Saves the item as an asset in the project (if we need it)
        //AssetDatabase.CreateAsset(newItem, filepath);
        //AssetDatabase.SaveAssets();

        Debug.Log(goalManagement.GetComponent<GoalManagement>().goalItems.Count);
        goalManagement.GetComponent<GoalManagement>().IniitializeGoals();
        ;
    }
}
