using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HealthWarningSFX : MonoBehaviour {

    private AudioSource sound;

    private void Awake()
    {
        EventManager.HealthChanged += HealthChanged;

        sound = GetComponent<AudioSource>();
    }

    private void HealthChanged(float a)
    {
        if(a < 0.25f)
        {
            if (!sound.isPlaying)
            {
                sound.loop = true;
                sound.Play();
            }
        }
        else
        {
            sound.loop = false;
        }
    }
}
