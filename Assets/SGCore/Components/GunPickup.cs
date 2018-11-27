using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour {

    public GameObject gun;

    private void Awake()
    {
        tag = "GunPickup";
    }
}
