using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public Light light;
    public float maxBright = 0;
    public float speed;

    private void Update()
    {
        if (light != null)
        {
            light.intensity = maxBright * Mathf.PerlinNoise(Time.time * speed, 0);
        }
    }
}
