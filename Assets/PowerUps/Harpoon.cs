using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    public void Activate(GameObject playerConcerned) {

        //Stun for when we'll create the harpoon.
        //GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = false;

    }

    public void Deactivate(GameObject playerConcerned) {

        //De-stuns
        //GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).GetComponent<DefaultMovement>().canMove = true;

    }

}