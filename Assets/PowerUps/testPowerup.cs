using UnityEngine;

public class testPowerup : MonoBehaviour {
    public void Activate(GameObject playerConcerned) {

        playerConcerned.GetComponent<Debuffs>().ApplyStun(5);

    }

    public void Deactivate(GameObject playerConcerned) {

        Debug.Log("Désactivé! par " + playerConcerned.name);

    }
}
