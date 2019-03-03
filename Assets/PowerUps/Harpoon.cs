using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour {

    public GameObject harpoon;

    public void Activate(GameObject playerConcerned) {
        if (GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)) != null){
            float xPos = 0;
            if(playerConcerned.transform.position.x > 0)
            {
                xPos = 4.4f;
            }
            else
            {
                xPos = -4.4f;
            }
            GameObject fish =  Instantiate((GameObject)Resources.Load("fisherman"), new Vector3(xPos, GameObject.Find("Main Camera").transform.position.y -6.5f), Quaternion.identity);
            fish.GetComponent<FollowCamera>().baseOffsetY = -6.5f;
            fish.GetComponent<Fisherman>().harpoon = harpoon;
            fish.GetComponent<Fisherman>().playerConcerned = playerConcerned;
            fish.GetComponent<Fisherman>().animTime = 0.9f;
            if ((GameObject.Find("Player" + ((playerConcerned.GetComponent<DefaultMovement>().player % 2) + 1)).transform.position.x > 0)){
                fish.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    public void Deactivate(GameObject playerConcerned) {



    }

}