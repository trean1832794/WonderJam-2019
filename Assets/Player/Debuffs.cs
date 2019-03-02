using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour
{

    private DefaultMovement movementScript;
    private float normalSpeed;
    public bool stunned;
    public Color stunColor;
    public float stunTime;
    public bool wet;
    public Color wetColor;
    public float wetTime;

    private void Awake()
    {

        movementScript = GetComponent<DefaultMovement>();
        normalSpeed = movementScript.xSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (stunTime <= 0.0f)
        {

            endStun();

        } else
        {

            stunTime -= Time.deltaTime;

        }

        if (wetTime <= 0.0f)
        {

            endWet();

        } else
        {

            wetTime -= Time.deltaTime;

        }

    }

    public void ApplyWet (float duration)
    {

        //divide speed by 2
        Debug.Log("Apply Wet");
        wetTime = duration;
        wet = true;
        movementScript.xSpeed = (movementScript.xSpeed / 2);

    }

    public void ApplyStun (float duration)
    {

        //set speed to 0
        stunned = true;
        stunTime = duration;
        movementScript.xSpeed = 0;

    }

    void endStun ()
    {

        stunned = false;
        movementScript.xSpeed = normalSpeed;

    }

    void endWet ()
    {
        wet = false;
        movementScript.xSpeed = normalSpeed;

    }

}
