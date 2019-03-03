using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser : MonoBehaviour
{
    public float geiserTime;
    private float offSetY;
    private float offSetYEnd;
    private bool downward;

    private void Start()
    {
        downward = false;
        offSetY = gameObject.GetComponent<FollowCamera>().baseOffsetY;
        offSetYEnd = offSetY + 12.5f;
    }

    private void FixedUpdate()
    {
        
            if (geiserTime > 0)
            {
            if (gameObject.GetComponent<FollowCamera>().baseOffsetY < offSetYEnd && downward == false)
            {

                gameObject.GetComponent<FollowCamera>().baseOffsetY += Time.fixedDeltaTime*10;
                GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size = new Vector2(gameObject.GetComponentInChildren<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.y + Time.fixedDeltaTime * 2f);
            }
            else if (downward == false)
            {
               downward = true;
               offSetYEnd -= 1f;
            }

            if(gameObject.GetComponent<FollowCamera>().baseOffsetY > offSetYEnd && downward == true)
            {
                gameObject.GetComponent<FollowCamera>().baseOffsetY -= Time.fixedDeltaTime*10;
                GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size = new Vector2(gameObject.GetComponentInChildren<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.y - Time.fixedDeltaTime * 2f);
            }
            else if(downward == true)
            {
                downward = false;
                offSetYEnd += 1f;
            }
                geiserTime -= Time.fixedDeltaTime;
            }
            else
            {
                if (gameObject.GetComponent<FollowCamera>().baseOffsetY > offSetY)
                {
                gameObject.GetComponent<FollowCamera>().baseOffsetY -= Time.fixedDeltaTime * 10;
                GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size = new Vector2(gameObject.GetComponentInChildren<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.y - Time.fixedDeltaTime * 2f);
            }
                else
                {
                    gameObject.GetComponent<FollowCamera>().baseOffsetY = offSetY;
                    Destroy(GameObject.Find("GeyzerTail"));
                    Destroy(gameObject);
                }
            }
   
    }
}
