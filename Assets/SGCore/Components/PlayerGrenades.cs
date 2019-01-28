using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrenades : MonoBehaviour {

    public GameObject grenadePrefab;

    private void Update()
    {
        if (Input.GetButtonDown("ThrowGrenade"))
        {
            if(LocalPlayerManager.grenades > 0)
            {
                LocalPlayerManager.UseGrenade();
                Instantiate(grenadePrefab, transform.position, transform.rotation);
            }
        }
    }
}
