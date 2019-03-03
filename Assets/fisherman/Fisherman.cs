using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisherman : MonoBehaviour
{

    public float animTime;
    private float offSetY;
    private float offSetYEnd;
    private bool animStarted;
    public GameObject harpoon;
    public GameObject playerConcerned;
    private bool harpoonShot;

    private void Start()
    {
        animTime = 0.9f;
        offSetY = GetComponent<FollowCamera>().baseOffsetY;
        offSetYEnd = offSetY + 3.5f;
    }

    private void FixedUpdate()
    {
        if(GetComponent<FollowCamera>().baseOffsetY < offSetYEnd && harpoonShot == false)
        {
            GetComponent<FollowCamera>().baseOffsetY += Time.fixedDeltaTime;
            animStarted = true;
        }
        else if(animStarted)
        {
            GetComponent<Animator>().SetFloat("shootSpeed", 1);
            animTime -= Time.fixedDeltaTime;
            if (!harpoonShot)
            {
                //shoot le harpon
                if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null)
                {
                    GameObject newHarpoon = Instantiate(harpoon, transform.position, Quaternion.identity);
                    newHarpoon.GetComponent<HarpoonObject>().targetPos = GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).transform.position;
                    newHarpoon.GetComponent<HarpoonObject>().target = GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1));
                }
                harpoonShot = true;

            }
        }

        if(animTime <= 0)
        {
            animStarted = false;
            GetComponent<Animator>().SetFloat("shootSpeed", 0);
            if(GetComponent<FollowCamera>().baseOffsetY > offSetY)
            {
                GetComponent<FollowCamera>().baseOffsetY -= Time.fixedDeltaTime;
                Debug.Log("NANANANDNADN");
            }
            else
            {
                Destroy(gameObject);
            }

        
        }
       
        

    }
 

  

}
