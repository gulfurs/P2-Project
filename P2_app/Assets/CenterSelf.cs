using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterSelf : MonoBehaviour
{
    public float dx, dy;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(dx, dy);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector2(dx, dy);
    }
}
