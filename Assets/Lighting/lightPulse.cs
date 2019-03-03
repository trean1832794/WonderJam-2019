using UnityEngine;

public class lightPulse : MonoBehaviour {

    float baseRange;
    float baseIntensity;
    float flameUpdateTimer = 0;
    Light light;

    private void Awake() {
        light = GetComponent<Light>();
        baseRange = light.range;
        baseIntensity = light.intensity;
    }

    void Update() {
        flameUpdateTimer++;

        if (flameUpdateTimer >= 2) {
            flameUpdateTimer = 0;
            if (light.range < baseRange * 1.20) {
                light.range += (float)Random.Range(0, 100) / 300;
            }
            if (light.range > baseRange * 0.80) {
                light.range -= (float)Random.Range(0, 100) / 300;
            }

            if (light.intensity < baseIntensity * 1.20) {
                light.intensity += (float)Random.Range(0, 100) / 300;
            }
            if (light.intensity > baseIntensity * 0.80) {
                light.intensity -= (float)Random.Range(0, 100) / 300;
            }
        }
        //light.range = Mathf.PingPong(Time.time * speed, maxDist);
    }
}
