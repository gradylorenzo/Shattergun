using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour {

    public int reloadAmount = 30;

    public void Interact()
    {
        Restock();
        DestroyObject(gameObject);
    }

    private void Restock()
    {
        LocalPlayerManager.StoreAmmo(reloadAmount);
    }
}
