using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float baseOffsetY;
    void Start()
    {
        baseOffsetY = transform.position.y - GameObject.Find("Main Camera").transform.position.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, GameObject.Find("Main Camera").transform.position.y + baseOffsetY, transform.position.z);
    }
}
