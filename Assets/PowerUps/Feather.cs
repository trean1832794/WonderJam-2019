using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public void Activate(GameObject playerConcerned) {

        playerConcerned.GetComponent<Rigidbody2D>().gravityScale -= 2;

    }

    public void Deactivate(GameObject playerConcerned) {

        if (playerConcerned != null) {
            playerConcerned.GetComponent<Rigidbody2D>().gravityScale += 2;
        }
    }
}
