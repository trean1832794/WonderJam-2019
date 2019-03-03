using UnityEngine;

public class StatGame : MonoBehaviour {
    GameObject faded;

    void Start() {
        faded = GameObject.Find("Faded");
    }

    public void callCamera() {
        faded.SetActive(false);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraScript>().StartGame();
        GameObject.Find("MainMenu").SetActive(false);
    }
}
