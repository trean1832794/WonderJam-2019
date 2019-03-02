using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuValueHolder : MonoBehaviour
{
    public bool isGhostPlatforms;
    public int difficulty;
    public Toggle togg;
    public Button easy, med, hard;
    // Start is called before the first frame update
    void Start()
    {
        difficulty = 1;
        togg.onValueChanged.AddListener(delegate {
            isGhostPlatforms = togg.isOn;
        });
        easy.onClick.AddListener(delegate {
            difficulty = 1;
        });
        med.onClick.AddListener(delegate {
            difficulty = 2;
        });
        hard.onClick.AddListener(delegate {
            difficulty = 3;
        });
    }
    public void setDifficulty(int diff)
    {
        this.difficulty = diff;
    }
    
        // Update is called once per frame
    void Update()
    {
        
    }
    

    
}
