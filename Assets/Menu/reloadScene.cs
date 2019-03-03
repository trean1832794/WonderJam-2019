using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    Button mainMenu;

    // Start is called before the first frame update
    void Start()
    {
        }
    public void reload() {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
