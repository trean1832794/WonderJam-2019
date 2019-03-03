using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWalk : MonoBehaviour
{

    public void Activate(GameObject playerConcerned) {

        //make player immune to wet debuff
        playerConcerned.GetComponent<Debuffs>().wetImmunity = true;

    }

    public void Deactivate(GameObject playerConcerned) {

        //make player vulnerable to wet debuff
        playerConcerned.GetComponent<Debuffs>().wetImmunity = false;

    }
}
