using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Player")) {
            int winnerNbr = ((collision.GetComponent<DefaultMovement>().player % 2) + 1);
            

            if (GameObject.Find("Player" + winnerNbr) != null) {
                Debug.Log(GameObject.Find("Player" + winnerNbr).name + " as gagne!");
            }
            if (winnerNbr == 1) {
                Debug.Log("Le joueur (2) a été éliminé avec " + Score.player1Score + " de score.");
            } else {
                Debug.Log("Le joueur (1) a été éliminé avec " + Score.player1Score + " de score.");
            }
            Destroy(collision.gameObject);
            GetComponent<SceneChange>().gotoDeathScreen();
        }
    }
}
