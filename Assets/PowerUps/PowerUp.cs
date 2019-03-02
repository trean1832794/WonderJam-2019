using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class onActivate : UnityEvent<GameObject> { }
[System.Serializable]
public class onDeactivate : UnityEvent<GameObject> { }

public class PowerUp : MonoBehaviour
{

    public float duration;
    private float remainingTime;
    public onActivate onActivate;
    public onDeactivate onDeactivate;
    private bool activated;
    private GameObject player;

    private void Awake()
    {

        activated = false;

    }


    // Update is called once per frame
    void Update()
    {
        
        if (activated)
        {
            if (remainingTime <= 0) {

                //deactivate powerup
                Deactivate(player);

            } else {

                remainingTime -= Time.deltaTime;

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Player") && !activated)
        {
            player = collision.gameObject;
            Activate(player);
            activated = true;
            remainingTime = duration;

            //désactive le sprite et le collider
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

        }

    }

    public void Activate (GameObject playerConcerned)
    {

        onActivate.Invoke(playerConcerned);

    }

    public void Deactivate (GameObject playerConcerned)
    {

        onDeactivate.Invoke(playerConcerned);
        Destroy(gameObject);

    }

}
