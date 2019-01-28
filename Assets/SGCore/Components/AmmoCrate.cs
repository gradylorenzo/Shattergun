using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCrate : MonoBehaviour {

    public int ammoCapacity = 150;
    public int grenadeCapacity = 5;
    public int reloadAmount = 30;
    public int grenadeAmount;
    public float ammoCooldown = 5.0f;
    public float grenadeCooldown = 10.0f;

    private float lastAmmoReload = 0.0f;
    private float lastGrenadeReload = 0.0f;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Restock();
        }

        if(ammoCapacity <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Restock()
    {
        if (lastAmmoReload + ammoCooldown < Time.time  && LocalPlayerManager.ammo < LocalPlayerManager.maxAmmo)
        {
            int ammoToRestock = Mathf.Min(ammoCapacity, reloadAmount);
            LocalPlayerManager.StoreAmmo(ammoToRestock);
            ammoCapacity -= ammoToRestock;
            lastAmmoReload = Time.time;
        }

        if(lastGrenadeReload + grenadeCooldown < Time.time && LocalPlayerManager.grenades < LocalPlayerManager.maxGrenades)
        {
            LocalPlayerManager.StoreGrenades(grenadeAmount);
            grenadeCapacity -= grenadeAmount;
            lastGrenadeReload = Time.time;
        }
    }
}
