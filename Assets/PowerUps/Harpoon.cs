using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    public GameObject harpoon;

    public void Activate(GameObject playerConcerned) {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null){
            GameObject newHarpoon = Instantiate(harpoon, transform.position, Quaternion.identity);
            newHarpoon.GetComponent<HarpoonObject>().targetPos = GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).transform.position;
            newHarpoon.GetComponent<HarpoonObject>().target = GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1));
        }
    }

    public void Deactivate(GameObject playerConcerned) {



    }

}