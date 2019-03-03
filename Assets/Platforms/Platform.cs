using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    private bool headEnter = false;
    private GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("MainCamera").transform.position.y - gameObject.transform.position.y > 10)
        {
            Destroy(gameObject);
        }

        if (headEnter == true) {
            if (player != null) { 
                if (player.transform.position.y - transform.position.y > 0.249263f) {
                    GetComponent<BoxCollider2D>().isTrigger = false;
                    headEnter = false;
                }
            }
        }
    }


    public void HeadCollision(GameObject player) {
        headEnter = true;
        this.player = player;
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
}
