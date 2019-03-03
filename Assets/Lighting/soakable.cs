using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soakable : MonoBehaviour {
    bool soak = false;

    private void Update() {
        if (soak == true) {
            GetComponentInChildren<Light>().intensity -= 0.70f;
            if (GetComponentInChildren<Light>().intensity <= 0) {
                GetComponentInChildren<Light>().enabled = false;
            }
        }
    }
    
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag.Equals("Water")) {
            this.GetComponent<Animator>().SetTrigger("Burn");
            GetComponentInChildren<lightPulse>().enabled = false;
            soak = true;
        }
    }
}