using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeIn : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void start()
    {
        Color color = this.GetComponent<MeshRenderer>().material.color;
        color.a = 0;
        color.a += Time.deltaTime;
        this.GetComponent<MeshRenderer>().material.color = color;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
