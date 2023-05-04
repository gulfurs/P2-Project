using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfilePicture : MonoBehaviour
{
    [SerializeField] private GameObject editButton;
    [SerializeField] private Image profilePicture;
    [SerializeField] private Image replaceProfilePicture;
    // Start is called before the first frame update
    private void Awake()
    {
       
    }
    private void Update()
    {
        profilePicture.sprite = replaceProfilePicture.sprite;
    }

    // This is a toggle
    // If the gameObject (The profile pictures) are inactive, it makes them active and vice versus
    public void ShowImages()
    {
        if (editButton.gameObject.activeSelf)
        {
            editButton.gameObject.SetActive(false);
        }
        else
        {
            editButton.gameObject.SetActive(true);
        }
    }
    public void ProfileChanger()
    {
       // string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        replaceProfilePicture = EventSystem.current.currentSelectedGameObject.GetComponent<Image>();
    }

}
