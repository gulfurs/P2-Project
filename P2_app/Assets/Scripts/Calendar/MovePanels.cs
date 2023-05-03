using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MovePanels : MonoBehaviour
{
    public GameObject calendarObj;
    public GameObject imagesObj;
    public GameObject todo;

    private Vector3 startPointCalendar;
    private Vector3 endPointCalendar;
    private int calendarIsMoving;

    private Vector3 startPointImages;
    private Vector3 endPointImages;

    private float startTime;
    public float t;

    // Start is called before the first frame update
    void Start()
    {
        calendarObj = GameObject.Find("Calendar");
        imagesObj = GameObject.Find("Fictional Images Title");
      

        startPointCalendar = calendarObj.transform.position;
        endPointCalendar = new Vector3(540, 1300 ,0);

        startPointImages = imagesObj.transform.position;
        endPointImages = new Vector3(254, 850, 0);
        startTime = Time.time;
        calendarIsMoving = 0;
    }

    // Update is called once per frame
    void Update()
    {
       if(calendarIsMoving == 1) 
        {
         MoveStuffUp();
        }
       else if(calendarIsMoving == 2)
        {
        MoveStuffDown();
        }
    }

    void MoveStuffUp()
    {
        imagesObj.transform.position = Vector3.Lerp(startPointImages, endPointImages, t);
        calendarObj.transform.position = Vector3.Lerp(startPointCalendar, endPointCalendar, t);
        t += 4f * Time.deltaTime;
        StartCoroutine(ExecuteAfterTimeActive(.3f));
    }
    void MoveStuffDown()
    {
        imagesObj.transform.position = Vector3.Lerp(endPointImages, startPointImages, t);
        calendarObj.transform.position = Vector3.Lerp(endPointCalendar, startPointCalendar, t);
        t += 4f * Time.deltaTime;
        Deactive();
    }
    public void ClickActivity ()
    {
        t = 0;
        calendarIsMoving = 1;
    }
    public void ClickEmpty()
    {
        t = 0;
        calendarIsMoving = 2;
    }
    IEnumerator ExecuteAfterTimeActive(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        todo.SetActive(true);
        calendarIsMoving = 0;
    }
    void Deactive()
    {
        StopAllCoroutines();
        todo.SetActive(false);
    }
}
