using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShove : MonoBehaviour
{

    public float pushForce;

    public void Activate(GameObject playerConcerned) {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null) {
            GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = false;
            //1 chance sur 2 que tu te fasse push a gauche à la place qu'à droite
            if (Random.Range(0.0f, 1.0f) > 0.49f) {
                GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<Rigidbody2D>().AddForce(new Vector3(-pushForce * 2, pushForce));
            } else {
                GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<Rigidbody2D>().AddForce(new Vector3(pushForce * 2, pushForce));
            }
        }
    }

    public void Deactivate (GameObject playerConcerned)
    {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null) {
            GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = true;
        }
    }
}
