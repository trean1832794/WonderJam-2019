using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {

            //Utiliser le debug.log pour get le joueur ayant survécu
            if (GameObject.Find("Player" + ((collision.GetComponent<DefaultMovement>().player % 2) + 1)) != null) {
                Debug.Log(GameObject.Find("Player" + ((collision.GetComponent<DefaultMovement>().player % 2) + 1)).name + " as gagne!");
            }
            Destroy(collision.gameObject);
            GetComponent<SceneChange>().gotoDeathScreen();
        }
    }
}
