using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeiserTail : MonoBehaviour
{
    public float heigth;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        gameObject.AddComponent<FollowCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
