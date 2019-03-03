using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{

    //public float timeBetweenEvents;
    public float timeBeforeEvent;
    public float hazardTime;
    public int nbEvents;
    public GameObject danger1;
    public GameObject danger2;

    public GameObject teleportObject;
    public GameObject fakeTeleportObject;
    private bool eventStarted;

    // Start is called before the first frame update
    void Start()
    {

       // timeBetweenEvents += hazardTime;
       // timeBeforeEvent = timeBetweenEvents;


    }

    // Update is called once per frame
    void Update()
    {
        if (eventStarted)
        {
            if (timeBeforeEvent <= hazardTime)
            {

                //activate hazards
                danger1.GetComponent<SpriteRenderer>().enabled = true;
                danger2.GetComponent<SpriteRenderer>().enabled = true;
                if (timeBeforeEvent <= 0)
                {

                    //activate event
                    StartEvent();
                    // timeBeforeEvent = timeBetweenEvents;
                    danger1.GetComponent<SpriteRenderer>().enabled = false;
                    danger2.GetComponent<SpriteRenderer>().enabled = false;
                    eventStarted = false;

                }
                else
                {

                    timeBeforeEvent -= Time.deltaTime;

                }


            }
            else
            {

                timeBeforeEvent -= Time.deltaTime;

            }
        }

    }
    public void StartEventTimer()
    {
        eventStarted = true;
    }
    public void StartEvent ()
    {

        Debug.Log("Start Event");
        switch (Random.Range(1,nbEvents))
        {

            case 1:
                //player swap
                Instantiate(teleportObject, GameObject.Find("Player1").transform.position,Quaternion.identity);
                Instantiate(fakeTeleportObject, GameObject.Find("Player2").transform.position, Quaternion.identity);


                break;
            case 2:



            break;
            case 3:



            break;

        }

    }

}
