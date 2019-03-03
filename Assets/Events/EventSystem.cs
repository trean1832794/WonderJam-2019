using UnityEngine;

public class EventSystem : MonoBehaviour {

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
    public AudioClip dangerSound;
    public AudioClip geyserSound;

    // Start is called before the first frame update
    void Start() {

        currentTime = hazardTime;


    }

    // Update is called once per frame
    void Update() {
        if (eventStarted) {

            if (currentTime <= 0) {

                StartEvent();
                eventStarted = false;
                danger1.GetComponent<SpriteRenderer>().enabled = false;
                danger2.GetComponent<SpriteRenderer>().enabled = false;


                currentTime = hazardTime;


            } else {

                currentTime -= Time.deltaTime;

            }

        }

    }
    public void StartEventTimer() {
        eventStarted = true;

        GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(dangerSound);

        danger1.GetComponent<SpriteRenderer>().enabled = true;
        danger2.GetComponent<SpriteRenderer>().enabled = true;

    }
    public void StartEvent() {
        int eventNbr;

        // boucle tant que (un des deux joueurs est mort ET l'event n'est pas un event pour un joueur solo)
        do { 
            eventNbr = Random.Range(1, nbEvents + 1);
        } while ((GameObject.Find("Player1") == null || GameObject.Find("Player2") == null) && eventNbr == 1);

        Debug.Log("Start Event");

        switch (eventNbr) {
            case 1:
                Debug.Log("Player Swap!");

                //player swap
                GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(teleportSound);
                Instantiate(teleportObject, GameObject.Find("Player1").transform.position, Quaternion.identity);
                Instantiate(fakeTeleportObject, GameObject.Find("Player2").transform.position, Quaternion.identity);

                break;
            case 2:
                Debug.Log("Water!");

                //water rise
                GameObject.Find("Water").GetComponent<Water>().WaterEvent();

                break;
            case 3:
                Debug.Log("Spin!");

                //camera spin
                GameObject.Find("Main Camera").GetComponent<CameraScript>().ReverseCamera();

                break;

            case 4:


                //Geiser
                if (GameObject.Find("Geyzer(Clone)") == null)
                {
                    GameObject geyGey = Instantiate((GameObject)Resources.Load("Geyzer"), new Vector3(Random.Range(-6.5f, -2.25f), GameObject.Find("Main Camera").transform.position.y - 9), Quaternion.identity);
                    geyGey.GetComponent<FollowCamera>().baseOffsetY = -9;
                    geyGey = Instantiate((GameObject)Resources.Load("Geyzer"), new Vector3(Random.Range(6.5f, 2.25f), GameObject.Find("Main Camera").transform.position.y - 9), Quaternion.identity);
                    geyGey.GetComponent<FollowCamera>().baseOffsetY = -9;
                    GameObject.Find("Main Camera").GetComponent<AudioSource>().PlayOneShot(geyserSound);
                }
                else
                {
                    GameObject.Find("Water").GetComponent<Water>().WaterEvent();
                }
                break;

        }

    }

}
