using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static int player1Score;
    public static int player2Score;
    public GameObject player1Text;
    public GameObject player2Text;
    private float startHeight;
    private int difficulty;

    // Start is called before the first frame update
    private void Awake()
    {

        startHeight = GameObject.Find("GameSettings").GetComponent<MenuValueHolder>().startHeight;
        difficulty = GameObject.Find("GameSettings").GetComponent<MenuValueHolder>().difficulty;

    }

    // Update is called once per frame
    void Update()
    {
        //calculate score for each player
        if (GameObject.Find("Player1") != null) {
            player1Score = (int)(difficulty * (GameObject.Find("Player1").transform.position.y - startHeight));
            player1Text.GetComponent<UnityEngine.UI.Text>().text = "SCORE: " + player1Score;
        }
        if (GameObject.Find("Player2") != null) {
            player2Score = (int)(difficulty * (GameObject.Find("Player2").transform.position.y - startHeight));
            player2Text.GetComponent<UnityEngine.UI.Text>().text = "SCORE: " + player2Score;
        }
    }
}
