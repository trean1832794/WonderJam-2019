using UnityEngine;

public class sceneStart : MonoBehaviour {
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    GameObject deathScreen;
    GameObject faded;
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
    }
}
