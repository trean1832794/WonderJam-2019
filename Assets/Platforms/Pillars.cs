using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillars : MonoBehaviour
{
    private SpriteRenderer sR;
    private BoxCollider2D bC;
    private float baseHeigth;
    private float baseOffset;
    // Start is called before the first frame update
    void Start()
    {
        sR = gameObject.GetComponent<SpriteRenderer>();
        baseHeigth = sR.size.y;
        bC = gameObject.GetComponent<BoxCollider2D>();
        baseOffset = bC.offset.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        sR.size = new Vector2(sR.size.x, baseHeigth + (transform.position.y * 2.0058157f));
        transform.position = new Vector3(transform.position.x,(GameObject.FindGameObjectWithTag("MainCamera").transform.position.y/2f), transform.position.z);
        bC.offset = new Vector2(bC.offset.x, baseOffset + transform.position.y);
    }
}
