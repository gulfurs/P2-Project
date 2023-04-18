using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void GoCalendar()
    {
        SceneManager.LoadScene("Calendar");
    }

    public void GoGoals()
    {
        SceneManager.LoadScene("Goals");
    }

    public void GoGroups()
    {
        SceneManager.LoadScene("Goals");
    }

    public void GoYou()
    {
        SceneManager.LoadScene("You");
    }
}
