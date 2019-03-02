using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    GameObject mainMenu;
    [SerializeField]
    GameObject optionsMenu;

    // Start is called before the first frame update
    void Start()
    {
        
     
    }
    public void quitApp()
    {
        Application.Quit();
    }
    public void changeScene(){
            Debug.Log("Button menu marche");
        mainMenu.SetActive(false);
        SceneManager.LoadScene("Game");

        }
    public void options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void goBackMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
