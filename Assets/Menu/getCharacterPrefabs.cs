using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getCharacterPrefabs : MonoBehaviour
{
    Button b1, b2, b3, b4,z1,z2,z3,z4;
    public GameObject pre1, pre2, pre3, pre4;
    public int p;
    // Start is called before the first frame update
    void Start()
    {
     
            b1 = GameObject.Find("b1").GetComponent<Button>();
            b2 = GameObject.Find("b2").GetComponent<Button>();
            b3 = GameObject.Find("b3").GetComponent<Button>();
            b4 = GameObject.Find("b4").GetComponent<Button>();
        z1 = GameObject.Find("z1").GetComponent<Button>();
        z2 = GameObject.Find("z2").GetComponent<Button>();
        z3 = GameObject.Find("z3").GetComponent<Button>();
        z4 = GameObject.Find("z4").GetComponent<Button>();
        if (p == 1)
        {
            b1.onClick.AddListener(delegate
            {
                GameObject.Find("Main Camera").GetComponent<CameraScript>().playerOnePrefab = pre1;
            });
            b2.onClick.AddListener(delegate
            {
                GameObject.Find("Main Camera").GetComponent<CameraScript>().playerOnePrefab = pre2;
            });
            b3.onClick.AddListener(delegate
            {
                GameObject.Find("Main Camera").GetComponent<CameraScript>().playerOnePrefab = pre3;
            });
            b4.onClick.AddListener(delegate
            {
                GameObject.Find("Main Camera").GetComponent<CameraScript>().playerOnePrefab = pre4;
            });
        }
            if (p == 2)
            {
                z1.onClick.AddListener(delegate
                {
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().playerTwoPrefab = pre1;
                });
                z2.onClick.AddListener(delegate
                {
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().playerTwoPrefab = pre2;
                });
                z3.onClick.AddListener(delegate
                {
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().playerTwoPrefab = pre3;
                });
                z4.onClick.AddListener(delegate
                {
                    GameObject.Find("Main Camera").GetComponent<CameraScript>().playerTwoPrefab = pre4;
                });


            }


        }
    public void debugMsg()
    {
        Debug.Log("Yo");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
