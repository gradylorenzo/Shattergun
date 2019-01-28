using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public GameObject defaultGun;
    public GameObject gun;

    public void Start()
    {
        if (defaultGun)
        {
            SwitchGun(defaultGun, defaultGun.GetComponent<Gun>().maxAmmo);
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            if(hit.transform.tag == "GunPickup")
            {
                SwitchGun(hit.transform.GetComponent<GunPickup>().gun, hit.transform.GetComponent<GunPickup>().ammo);
                Destroy(hit.transform.gameObject);
            }

            else if(hit.transform.tag == "Door")
            {
                hit.transform.parent.gameObject.SendMessage("Interact");
                Debug.Log("Interacted");
            }
            else
            {
                hit.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public void SwitchGun(GameObject g, int a)
    {
        //Drop the current gun
        if (gun)
        {
            GameObject droppedGun = Instantiate(gun.GetComponent<Gun>().Config.pickupPrefab, transform.position + transform.forward, transform.rotation);
            droppedGun.GetComponent<GunPickup>().ammo = gun.GetComponent<Gun>().ammo;
        }

        //Destroy the current gun
        Destroy(gun);

        //Attach the new gun
        if (g)
        {
            gun = Instantiate(g, transform.position, transform.rotation);
            gun.transform.parent = transform;
            gun.GetComponent<Gun>().ammo = a;
            EventManager.GunChanged(g.GetComponent<Gun>().Config.name);
        }
    }
}
