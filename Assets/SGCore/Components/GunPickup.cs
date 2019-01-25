using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour {

    public GameObject gun;
    public int ammo;
    private void Awake()
    {
        tag = "GunPickup";
    }
}
