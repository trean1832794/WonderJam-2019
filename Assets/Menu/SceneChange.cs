using UnityEngine;

public class SceneChange : MonoBehaviour {
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    GameObject deathScreen;

    void Start()
    {
       
    }
    public void quitApp() {
        Application.Quit();
    }

    public void changeScene() {
        Debug.Log("Button menu marche");
        mainMenu.SetActive(false);
    }

    public void options() {
        mainMenu.SetActive(false);
        deathScreen.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void goBackMainMenu() {
        optionsMenu.SetActive(false);
        deathScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void gotoDeathScreen() {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        deathScreen.SetActive(true);
    }
}
