using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{

    //private SpriteRenderer sR;
    //private BoxCollider2D bC;
    private float baseHeigth;
    private bool pillarSpawned;
    public float spawnThreshold;
    //private float baseOffset;
    // Start is called before the first frame update
    void Start()
    {
        /* sR = gameObject.GetComponent<SpriteRenderer>();
         baseHeigth = sR.size.y;
         bC = gameObject.GetComponent<BoxCollider2D>();
         baseOffset = bC.offset.y;
         */
        baseHeigth = transform.position.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y - GameObject.FindGameObjectWithTag("MainCamera").transform.position.y < -spawnThreshold && pillarSpawned == false)
        {
            Instantiate(gameObject, new Vector3(transform.position.x, transform.position.y + gameObject.GetComponent<SpriteRenderer>().size.y, transform.position.z), Quaternion.identity);
            pillarSpawned = true;
        }

        if(transform.position.y - GameObject.FindGameObjectWithTag("MainCamera").transform.position.y < -20)
        {
            Destroy(gameObject);
        }

        /*sR.size = new Vector2(sR.size.x, baseHeigth + (transform.position.y * 2.0058157f));
        transform.position = new Vector3(transform.position.x,(GameObject.FindGameObjectWithTag("MainCamera").transform.position.y/2f), transform.position.z);
        bC.offset = new Vector2(bC.offset.x, baseOffset + transform.position.y);
        */
    }
}
