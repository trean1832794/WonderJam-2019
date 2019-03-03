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
        GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x,GetComponent<SpriteRenderer>().size.y);
        GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, GetComponent<BoxCollider2D>().size.y / 2f);
    }
}
