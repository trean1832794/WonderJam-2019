﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShove : MonoBehaviour
{

    public float pushForce;

    public void Activate(GameObject playerConcerned)
    {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null) {
            GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = false;
            GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<Rigidbody2D>().AddForce(new Vector3(pushForce, pushForce * 2));
        }
    }

    public void Deactivate (GameObject playerConcerned)
    {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null) {
            GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = true;
        }
    }
}
