using UnityEngine;

public class SceneChange : MonoBehaviour {
    [SerializeField]
    public GameObject mainMenu;
    [SerializeField]
    public GameObject optionsMenu;
    [SerializeField]
    public GameObject deathScreen;
    [SerializeField]
    public GameObject characterMenu;

    void Start()
    {
        mainMenu = GameObject.Find("Canvas").GetComponent<SceneChange>().mainMenu;
        optionsMenu = GameObject.Find("Canvas").GetComponent<SceneChange>().optionsMenu;
        deathScreen = GameObject.Find("Canvas").GetComponent<SceneChange>().deathScreen;
        characterMenu = GameObject.Find("Canvas").GetComponent<SceneChange>().characterMenu;
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
    public void goToCharactersMenu()
    {
        mainMenu.SetActive(false);
        deathScreen.SetActive(false);
        optionsMenu.SetActive(false);
        characterMenu.SetActive(true);
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
