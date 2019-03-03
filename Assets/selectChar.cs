using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectChar : MonoBehaviour
{
    GameObject mainCamera;
    Button pre1,pre2,pre3,pre4;
    public GameObject prefab1, prefab2, prefab3, prefab4;
    public int p;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        pre1 = transform.Find("pre1").GetComponent<Button>();
        pre2 = transform.Find("pre2").GetComponent<Button>();
        pre3 = transform.Find("pre3").GetComponent<Button>();
        pre4 = transform.Find("pre4").GetComponent<Button>();
        if (p == 1)
        {
            pre1.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerOnePrefab = prefab1;
            });
            pre2.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerOnePrefab = prefab2;
            });
            pre3.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerOnePrefab = prefab3;
            });
            pre4.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerOnePrefab = prefab4;
            });
        }
        else if (p == 2)
        {
            pre1.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerTwoPrefab = prefab1;
            });
            pre2.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerTwoPrefab = prefab2;
            });
            pre3.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerTwoPrefab = prefab3;
            });
            pre4.onClick.AddListener(delegate
            {
                mainCamera.GetComponent<CameraScript>().playerTwoPrefab = prefab4;
            });
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
