using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class ExpandLeaderboard : MonoBehaviour
{
    public GameObject postObject;
    public RectTransform expandArrow;
    private Vector3 startPointPost;
    private Vector3 endPointPost;
    private int postIsMoving;
    public float t;
    private bool onStart;

    // Start is called before the first frame update
    void Start()
    {
        startPointPost = postObject.transform.localPosition;
        endPointPost = new Vector3(-500, startPointPost.y, 0);
        onStart = true;
        postIsMoving = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        postObject.transform.localPosition = Vector3.Lerp(startPointPost, endPointPost, t);
        t += 4f * Time.deltaTime;
        StartCoroutine(ExecuteAfterTimeActive(.3f));
    }
    void MoveStuffRight()
    {
        postObject.transform.localPosition = Vector3.Lerp(endPointPost, startPointPost, t);
        t += 4f * Time.deltaTime;
        Deactive();
    }
    public void ClickArrowFromStart()
    {
        t = 0;
        expandArrow.Rotate(0, 0, 180);
        if(onStart)
        {
            postIsMoving = 1;
            onStart = false;
        }
        else if(!onStart)
        { 
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
