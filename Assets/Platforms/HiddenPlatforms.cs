using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlatforms : MonoBehaviour
{
    private float alpha = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (true)
        {
            if(transform.position.y - GameObject.Find("Main Camera").transform.position.y < 3)
            {
                if(alpha > 0) { 
                alpha -= Time.deltaTime;
                }
                else
                {
                    alpha = 0;
                }
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, alpha);
            }
        }
    }
}
