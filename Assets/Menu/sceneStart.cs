using UnityEngine;

public class sceneStart : MonoBehaviour {
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    GameObject deathScreen;
    GameObject characterMenu;

    // Start is called before the first frame update
    public void Start() {
        characterMenu = GameObject.Find("CharactersMenu");
        characterMenu.SetActive(false);
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        deathScreen.SetActive(false);
        GameObject.Find("Faded").SetActive(true);
    }
}
