using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpUp : MonoBehaviour {

    public void Activate(GameObject playerConcerned) {

        playerConcerned.GetComponent<DefaultMovement>().baseNbJumps++;
        playerConcerned.GetComponent<DefaultMovement>().nbJumps = playerConcerned.GetComponent<DefaultMovement>().baseNbJumps;

    }

    public void Deactivate(GameObject playerConcerned) {

        playerConcerned.GetComponent<DefaultMovement>().baseNbJumps--;

    }
}