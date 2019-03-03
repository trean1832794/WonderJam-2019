using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonObject : MonoBehaviour
{

    public float moveSpeed;
    public Vector3 targetPos;
    public GameObject target;
    public float rotationOffset;
    Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {

        diff = targetPos - transform.position;
        
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(diff.y, diff.x) + rotationOffset);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPos + diff, moveSpeed);
        if (Vector2.Distance(GameObject.FindGameObjectWithTag("MainCamera").transform.position, transform.position) >= 15)
        {

            Destroy(gameObject);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject == target)
        {

            collision.gameObject.GetComponent<Debuffs>().ApplyStun(1f);
            Destroy(gameObject);

        }

    }

}
