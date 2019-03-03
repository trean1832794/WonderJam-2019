using UnityEngine;

public class sceneStart : MonoBehaviour {
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    GameObject deathScreen;

    // Start is called before the first frame update
    public void Awake() {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        deathScreen.SetActive(false);
        GameObject.Find("Faded").SetActive(true);
    }
}
