using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class Flashlight : MonoBehaviour {

    private Light flashlight;

    private void Start()
    {
        flashlight = GetComponent<Light>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("ToggleFlashlight"))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
