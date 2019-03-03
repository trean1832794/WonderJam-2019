using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHeader : MonoBehaviour
{

    private float displayTime = 3.0f;
    [HideInInspector]
    public GameObject player;
    public float yOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
            transform.position = player.transform.position + new Vector3(0, yOffset);

            if (displayTime > 0.0f)
            {

                displayTime -= Time.deltaTime;

            }
            else
            {

                Destroy(gameObject);

            }

        } else
        {

            Destroy(gameObject);

        }

    }

}
