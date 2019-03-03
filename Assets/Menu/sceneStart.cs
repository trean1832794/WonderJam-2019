using UnityEngine;

public class sceneStart : MonoBehaviour {
    [SerializeField]
    public GameObject mainMenu;
    [SerializeField]
    public GameObject optionsMenu;
    [SerializeField]
    public GameObject deathScreen;
    public GameObject faded;
    [SerializeField]
    public GameObject charactersMenu;

    // Start is called before the first frame update
    public void Awake() {
        faded = GameObject.Find("Faded");
        ClearData();
    }


    public void ClearData()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        deathScreen.SetActive(false);
        faded.SetActive(true);
        charactersMenu.SetActive(false);
    }
}
