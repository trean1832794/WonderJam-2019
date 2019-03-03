using UnityEngine;
public class EndGame : MonoBehaviour {
    public void callCam() {
        GameObject mainMenu = GameObject.Find("MainMenu");
        mainMenu.SetActive(true);
        mainMenu.GetComponent<fadeIn>().start();
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().EndGame();
    }
}