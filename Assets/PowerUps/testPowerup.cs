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

        playerConcerned.GetComponent<Debuffs>().ApplyStun(5);

    } 

    public void Deactivate (GameObject playerConcerned)
    {

        Debug.Log("Désactivé! par " + playerConcerned.name);

    }
}
