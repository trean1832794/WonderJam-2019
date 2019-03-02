using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwap : MonoBehaviour
{

    private GameObject player1;
    private GameObject player2;
    private Vector3 player1Pos;
    private Vector3 player2Pos;

    public void Activate ()
    {

        //do stuff
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player1Pos = player1.transform.position;
        player2Pos = player2.transform.position;

        player1.transform.position = player2Pos;
        player2.transform.position = player1Pos;

    }

}
