using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MovePanels : MonoBehaviour
{
    // Objects to move
    public GameObject calendarObj;
    public GameObject imagesObj;
    // Object to activate / deactivate
    public GameObject todo;


    private Vector3 startPointCalendar;
    private Vector3 endPointCalendar;
    private int calendarIsMoving;

    private Vector3 startPointImages;
    private Vector3 endPointImages;

    // T is used to move the object smoothly
    public float t;

    void Start()
    {
        // Get the startpoint of the object
        startPointCalendar = calendarObj.transform.position;
        // Sets the enpoint of the object
        endPointCalendar = new Vector3(540, 1300 ,0);

        // Get the startpoint of the object
        startPointImages = imagesObj.transform.position;
        // Sets the enpoint of the object
        endPointImages = new Vector3(254, 850, 0);

        calendarIsMoving = 0;
    }

    void Update()
    {
        // Moves the objects
       if(calendarIsMoving == 1 && imagesObj.transform.position != endPointImages) 
        {
         MoveStuffUp();
        }
       else if(calendarIsMoving == 2 && imagesObj.transform.position != startPointImages)
        {
        MoveStuffDown();
        }
    }

    void MoveStuffUp()
    {
        // Lerp the objects from startpoint to the endpoint at t speed
        imagesObj.transform.position = Vector3.Lerp(startPointImages, endPointImages, t);
        calendarObj.transform.position = Vector3.Lerp(startPointCalendar, endPointCalendar, t);

        // Gradually increase the speed over time to make the lerp smoother
        t += 4f * Time.deltaTime;

        // after .3f set post.isMoving to = 0
        StartCoroutine(ExecuteAfterTimeActive(.3f));
    }
    void MoveStuffDown()
    {
        // does the same as the previous function, but moves the object from endpos to startpos
        imagesObj.transform.position = Vector3.Lerp(endPointImages, startPointImages, t);
        calendarObj.transform.position = Vector3.Lerp(endPointCalendar, startPointCalendar, t);
        t += 4f * Time.deltaTime;

        // Deactivate the courotine if the user spams the button
        Deactive();
    }

    // Function that sits on the active days buttons
    public void ClickActivity ()
    {
        t = 0;
        calendarIsMoving = 1;
    }
    // Function that sits on the empty days buttons
    public void ClickEmpty()
    {
        t = 0;
        calendarIsMoving = 2;
    }
    IEnumerator ExecuteAfterTimeActive(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        // Activate todo
        todo.SetActive(true);
        calendarIsMoving = 0;
    }
    void Deactive()
    {
        StopAllCoroutines();
        // Deactivate todo
        todo.SetActive(false);
    }
}
