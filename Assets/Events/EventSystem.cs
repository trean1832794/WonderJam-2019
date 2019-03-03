using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{

    //public float timeBetweenEvents;
    public float currentTime;
    public float hazardTime;
    public int nbEvents;
    public GameObject danger1;
    public GameObject danger2;

    public GameObject teleportObject;
    public GameObject fakeTeleportObject;
    private bool eventStarted;
    public AudioClip teleportSound;

    // Start is called before the first frame update
    void Start()
    {

        currentTime = hazardTime;


    }

    // Update is called once per frame
    void Update()
    {
        if (eventStarted)
        {

            if (currentTime <= 0)
            {

                StartEvent();
                eventStarted = false;
                danger1.GetComponent<SpriteRenderer>().enabled = false;
                danger2.GetComponent<SpriteRenderer>().enabled = false;
                currentTime = hazardTime;


            } else
            {

                currentTime -= Time.deltaTime;

            }

        }

    }
    public void StartEventTimer()
    {
        eventStarted = true;

        danger1.GetComponent<SpriteRenderer>().enabled = true;
        danger2.GetComponent<SpriteRenderer>().enabled = true;

    }
    public void StartEvent ()
    {

        Debug.Log("Start Event");
        switch (Random.Range(1,nbEvents+1))
        {

            case 1:

                Debug.Log("Player Swap!");

                //player swap
                if (GameObject.Find("Player1") != null && GameObject.Find("Player2") != null) {
                GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(teleportSound);
                    Instantiate(teleportObject, GameObject.Find("Player1").transform.position, Quaternion.identity);
                    Instantiate(fakeTeleportObject, GameObject.Find("Player2").transform.position, Quaternion.identity);
                }

                break;
            case 2:

                //water rise

            break;
            case 3:

                //camera spin


            break;

        }

    }

}
