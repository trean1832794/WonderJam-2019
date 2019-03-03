using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{

    public AudioClip mainMenuTheme;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void NewGame()
    {
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(player);
        }

        GameObject.Find("Canvas").GetComponent<sceneStart>().ClearData();
        GameObject.Find("Main Camera").GetComponent<CameraScript>().ResetGame();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = mainMenuTheme;
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();


    }
}
