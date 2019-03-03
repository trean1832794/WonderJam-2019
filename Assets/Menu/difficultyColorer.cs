using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class difficultyColorer : MonoBehaviour
{
    public Button easy, med, hard;

    // Start is called before the first frame update
    void Start()
    {
        easy = GameObject.Find("Easy").GetComponent<Button>();
        med = GameObject.Find("Medium").GetComponent<Button>();
        hard = GameObject.Find("Hard").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
