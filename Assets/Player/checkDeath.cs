﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDeath : MonoBehaviour
{
    float endScreenTimer = 0;
    bool activateTimer = false;

    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            int winnerNbr = ((collision.GetComponent<DefaultMovement>().player % 2) + 1);
            

            if (GameObject.Find("Player" + winnerNbr) != null) {
                Debug.Log(GameObject.Find("Player" + winnerNbr).name + " as gagne!");
            }
            if (winnerNbr == 1) {
                Debug.Log("Le joueur (2) a été éliminé avec " + Score.player2Score + " de score.");
            } else {
                Debug.Log("Le joueur (1) a été éliminé avec " + Score.player1Score + " de score.");
            }
            Destroy(collision.gameObject);
            activateTimer = true;
        }
    }

    private void Update() {
        if (activateTimer) {
            endScreenTimer += Time.deltaTime;
            if (endScreenTimer >= 2) {
                GetComponent<SceneChange>().gotoDeathScreen();
                activateTimer = false;
            }
        }
    }
}