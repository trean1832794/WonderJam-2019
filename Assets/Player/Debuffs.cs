using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debuffs : MonoBehaviour
{

    private DefaultMovement movementScript;
    private SpriteRenderer playerSprite;
    private Color baseColor;
    private float normalSpeed;
    public bool stunned;
    public Color stunColor;
    public float stunTime;
    public bool wet;
    public bool wetImmunity;
    public Color wetColor;
    public float wetTime;

    private void Awake()
    {

        movementScript = GetComponent<DefaultMovement>();
        playerSprite = GetComponent<SpriteRenderer>();
        baseColor = playerSprite.color;
        normalSpeed = movementScript.xSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stunned)
        {

            if (stunTime <= 0.0f)
            {

                endStun();

            }
            else
            {

                stunTime -= Time.deltaTime;

            }

        }

            if (wet)
            {
                if (wetTime <= 0.0f)
                {

                    endWet();

                }
                else
                {

                    wetTime -= Time.deltaTime;

                }

            }


    }

    public void ApplyWet (float duration)
    {

        Debug.Log("Apply Wet");
        wetTime = duration;
        wet = true;
        playerSprite.color = wetColor;

        if (!wetImmunity)
        {

            //divide speed by 2
            movementScript.xSpeed = (normalSpeed / 2);

        }

    }

    public void ApplyStun (float duration)
    {

        //set speed to 0
        stunned = true;
        stunTime = duration;
        playerSprite.color = stunColor;

        movementScript.canMove = false;

    }

    void endStun ()
    {

        stunned = false;
        playerSprite.color = baseColor;

        movementScript.canMove = true;

    }

    void endWet ()
    {

        Debug.Log("End Wet");
        wet = false;
        playerSprite.color = baseColor;

        movementScript.xSpeed = normalSpeed;

    }

}
