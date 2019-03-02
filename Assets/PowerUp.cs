using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{

    public float duration;
    public float remainingTime;
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;
    public bool activated;

    private void Awake()
    {

        activated = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        
        if (activated)
        {
            if (remainingTime <= 0) {

                //deactivate powerup
                Deactivate();

            } else {

                remainingTime -= Time.deltaTime;

            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag.Equals("Player"))
        {

            Activate();
            activated = true;
            remainingTime = duration;

            //désactive le sprite et le collider
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;

        }

    }

    public void Activate ()
    {

        Debug.Log("on Activate fonctionne");
        onActivate.Invoke();

    }

    public void Deactivate ()
    {

        onDeactivate.Invoke();
        Destroy(gameObject);

    }

}
