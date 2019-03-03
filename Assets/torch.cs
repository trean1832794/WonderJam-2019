using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (transform.position.y - GameObject.Find("Main Camera").transform.position.y < -20)
        {

            Destroy(gameObject);

        } 

    }
}
