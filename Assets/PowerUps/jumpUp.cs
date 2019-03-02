using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpUp : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Activate(GameObject playerConcerned) {

        playerConcerned.GetComponent<DefaultMovement>().baseNbJumps++;

    }

    public void Deactivate(GameObject playerConcerned) {

        playerConcerned.GetComponent<DefaultMovement>().baseNbJumps--;

    }
}