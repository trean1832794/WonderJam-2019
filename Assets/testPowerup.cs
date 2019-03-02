using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate (GameObject playerConcerned)
    {

        Debug.Log("Activé! par " + playerConcerned.name);

    } 

    public void Deactivate (GameObject playerConcerned)
    {

        Debug.Log("Désactivé! par " + playerConcerned.name);

    }
}
