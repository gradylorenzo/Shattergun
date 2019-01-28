using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestockSFX : MonoBehaviour {

    private void Awake()
    {
        EventManager.AmmoInStorageIncreased += AmmoInStorageIncreased;
        EventManager.GrenadesIncreased += GrenadesIncreased;
    }

    public void AmmoInStorageIncreased(int a)
    {
        GetComponent<AudioSource>().Play();
    }

    private void GrenadesIncreased(int a)
    {
        GetComponent<AudioSource>().Play();
    }
}
