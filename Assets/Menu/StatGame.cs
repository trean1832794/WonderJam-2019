using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatGame : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject faded;
    void Start()
    {
        faded=GameObject.Find("Faded");
    }
    public void callCamera() {
        faded.SetActive(false);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().StartGame();
        GameObject.Find("MainMenu").SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
