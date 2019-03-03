using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    public float pushForce;

    public void Activate(GameObject playerConcerned) {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null) {
            GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -pushForce));
        }
    }

    public void Deactivate(GameObject playerConcerned) {

    }
}
