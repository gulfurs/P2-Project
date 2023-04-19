using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroll_script : MonoBehaviour
{
    
    public ScrollRect scrollRect;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
                {
                scrollRect.verticalNormalizedPosition += touch.deltaPosition.y / scrollRect.content.rect.height;
                }
            }
        }
    }
