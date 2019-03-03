using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float wetTime;
    private float baseWetTime;
    private float offSetY;
    private float offSetYEnd;
    private bool waterEvent = false;

    private void Start()
    {
        baseWetTime = wetTime;
    }

    private void FixedUpdate()
    {
        if (waterEvent)
        {
            if (wetTime > 0)
            {
                if (GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY < offSetYEnd)
                {
                    GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY += Time.fixedDeltaTime;
                }
                else
                {
                    GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY = offSetYEnd;
                }
                wetTime -= Time.fixedDeltaTime;
            }
            else
            {
                if (GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY > offSetY)
                {
                    GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY -= Time.fixedDeltaTime*3;
                }
                else
                {
                    GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY = offSetY;
                    waterEvent = false;
                    wetTime = baseWetTime;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Equals("Player"))
        {

            collision.gameObject.GetComponent<Debuffs>().ApplyWet(baseWetTime);

        }

    }

    public void WaterEvent()
    {
        offSetY = GameObject.Find("Water").GetComponent<FollowCamera>().baseOffsetY;
        offSetYEnd = offSetY + Random.Range(2f, 6f);
        waterEvent = true;
    }

}
