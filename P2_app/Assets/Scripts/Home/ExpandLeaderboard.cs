using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ExpandLeaderboard : MonoBehaviour
{
    // Object to move
    public GameObject postObject;
    // The arrow button
    public RectTransform expandArrow;

    private Vector3 startPointPost;
    private Vector3 endPointPost;

    private int postIsMoving;
    // T is used to move the object smoothly
    public float t;
    private bool onStart;

    void Start()
    {
        // Get the startpoint of the object
        startPointPost = postObject.transform.localPosition;
        // Transform the object -500 on the x axis
        endPointPost = new Vector3(-500, startPointPost.y, 0);
        // See if post is at it's starting pos
        onStart = true;
        postIsMoving = 0;
    }

    void Update()
    {
        // Moves the object
        if (postIsMoving == 1 && postObject.transform.localPosition != endPointPost)
        {
            MoveStuffLeft();
        }
        else if (postIsMoving == 2 && postObject.transform.localPosition != startPointPost)
        {
            MoveStuffRight();
        }
    }

    void MoveStuffLeft()
    {
        // Lerp the object from startpoint to the endpoint at t speed
        postObject.transform.localPosition = Vector3.Lerp(startPointPost, endPointPost, t);
        // Gradually increase the speed over time to make the lerp smoother
        t += 4f * Time.deltaTime;
        // after .3f set post.isMoving to = 0
        StartCoroutine(ExecuteAfterTimeActive(.3f));
    }
    void MoveStuffRight()
    {
        // does the same as the previous function, but moves the object from endpos to startpos
        postObject.transform.localPosition = Vector3.Lerp(endPointPost, startPointPost, t);
        t += 4f * Time.deltaTime;
        // Deactivate the courotine if the user spams the button
        Deactive();
    }
    // This function sits on the arrowbutton which is why it's public
    public void ClickArrowFromStart()
    {
        // Set t=0 so the object starts from 0 again and gradualy moves faster
        t = 0;
        // Rotate the sprite 180 degrees to make it point in the opposite direction
        expandArrow.Rotate(0, 0, 180);
        // onStart = true means we are on the start page normally and the object is not moved yet
        if(onStart)
        {
            // Starts the MoveStuffLeft funtion through update
            postIsMoving = 1;
            // Now we are no longer on the normal homepage so set onstart to false 
            // This means the next time we click the button th will play the else if statement bellow
            onStart = false;
        }
        // This means the object is moved 
        else if(!onStart)
        {
            // Starts the MoveStuffRight funtion through update
            postIsMoving = 2;
            onStart = true;
        }
    }
   
    IEnumerator ExecuteAfterTimeActive(float time)
    {
        yield return new WaitForSeconds(time);
        postIsMoving = 0;
    }
    void Deactive()
    {
        StopAllCoroutines();
    }
}
