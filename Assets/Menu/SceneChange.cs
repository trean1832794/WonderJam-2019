using UnityEngine;

public class SceneChange : MonoBehaviour {
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    GameObject deathScreen;
    [SerializeField]
    GameObject characterMenu;

    void Start()
    {
        mainMenu = GameObject.Find("Canvas").GetComponent<sceneStart>().mainMenu;
        characterMenu = GameObject.Find("Canvas").GetComponent<sceneStart>().charactersMenu;
        optionsMenu = GameObject.Find("Canvas").GetComponent<sceneStart>().optionsMenu;
        deathScreen = GameObject.Find("Canvas").GetComponent<sceneStart>().deathScreen;
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
    public void goToCharacterMenu()
    {
        mainMenu.SetActive(false);
        characterMenu.SetActive(true);
    }
    public void goBackMainMenu() {
        optionsMenu.SetActive(false);
        deathScreen.SetActive(false);
        characterMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void gotoDeathScreen() {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(false);
        deathScreen.SetActive(true);
    }
}
