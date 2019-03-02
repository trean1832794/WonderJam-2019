using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EndGame : MonoBehaviour
{
    public void callCam()
    {
        GameObject mainMenu = GameObject.Find("MainMenu");
        mainMenu.SetActive(true);
        mainMenu.GetComponent<fadeIn>().start();
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().EndGame();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
