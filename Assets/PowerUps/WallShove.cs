using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShove : MonoBehaviour
{

    public float pushForce;

    public void Activate(GameObject playerConcerned)
    {

        GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = false;
        GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<Rigidbody2D>().AddForce(new Vector3(pushForce*2,pushForce));

    }

    public void Deactivate (GameObject playerConcerned)
    {

        GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = true;

    }

}
