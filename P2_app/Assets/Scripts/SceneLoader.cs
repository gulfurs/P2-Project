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
        SceneManager.LoadScene("Groups");
    }

    public void GoYou()
    {
        SceneManager.LoadScene("You");
    }

    public void GoNewGoal()
    {
        SceneManager.LoadScene("New_Goal");
    }
      public void GoGoalFitness()
    {
        SceneManager.LoadScene("Goals_Fitness");
    }

    public void GoTrackGoal()
    {
        SceneManager.LoadScene("Track_Goal");
    }

}
