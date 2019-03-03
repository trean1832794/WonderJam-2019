using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChoice : MonoBehaviour
{
    public float maxY;
    public float minY;
    public float maxX;
    public float minX;
    public float ySize;
    public float xSize;

    public GameObject prefabToChange;
    public int player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {
        maxY = transform.position.y + ySize;
        minY = transform.position.y - ySize;
        maxX = transform.position.x + xSize;
        minX = transform.position.x - xSize;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);       
        if (pos.y < maxY && pos.y > minY && pos.x > minX && pos.x < maxX && Input.GetMouseButtonDown(0))
        {
            if(player == 1)
            {
                GameObject.Find("Main Camera").GetComponent<CameraScript>().playerOnePrefab = prefabToChange;

            }
            else
            {
                GameObject.Find("Main Camera").GetComponent<CameraScript>().playerTwoPrefab = prefabToChange;
            }
        }
    }
}
