using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geiser : MonoBehaviour
{
    public float geiserTime;
    private float offSetY;
    private float offSetYEnd;
    private bool downward;
    private float basePosY;

    private void Start()
    {
        downward = false;
        offSetY = gameObject.GetComponent<FollowCamera>().baseOffsetY;
        offSetYEnd = offSetY + 11.5f;
        Debug.Log(offSetYEnd);
        
    }

    private void FixedUpdate()
    {
        
            if (geiserTime > 0)
            {
            if (gameObject.GetComponent<FollowCamera>().baseOffsetY < offSetYEnd && downward == false)
            {
               
                gameObject.GetComponent<FollowCamera>().baseOffsetY += Time.fixedDeltaTime*10;
                if (transform.position.x > 0)
                {
                    GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size = new Vector2(GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.y + Time.fixedDeltaTime * 2f);
                }
                else {
                    GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size = new Vector2(GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size.y + Time.fixedDeltaTime * 2f);
                }
            }
            else if (downward == false)
            {
               downward = true;
               offSetYEnd -= 1f;
            }

            if(gameObject.GetComponent<FollowCamera>().baseOffsetY > offSetYEnd && downward == true)
            {
                gameObject.GetComponent<FollowCamera>().baseOffsetY -= Time.fixedDeltaTime*10;
                if (transform.position.x > 0)
                {
                    GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size = new Vector2(GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.y - Time.fixedDeltaTime * 2f);
                }
                else
                {
                    GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size = new Vector2(GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size.y - Time.fixedDeltaTime * 2f);
                }


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
                if(transform.position.x > 0)
                {
                    GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size = new Vector2(GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail").GetComponent<SpriteRenderer>().size.y - Time.fixedDeltaTime * 2f);

                }
                else
                {
                    GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size = new Vector2(GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size.x, GameObject.Find("GeyzerTail2").GetComponent<SpriteRenderer>().size.y - Time.fixedDeltaTime * 2f);

                }
            }
                else
                {
                    gameObject.GetComponent<FollowCamera>().baseOffsetY = offSetY;
                if (transform.position.x > 0)
                {
                    Destroy(GameObject.Find("GeyzerTail"));
                }
                else
                {
                    Destroy(GameObject.Find("GeyzerTail2"));
                }
                    Destroy(gameObject);
                }
            }
   
    }
}
