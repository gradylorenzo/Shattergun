using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour {

    public GameObject defaultGun;
    public GameObject gun;
    public GameObject pickupPrefab;

    public void Start()
    {
        if (defaultGun)
        {
            SwitchGun(defaultGun);
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
                SwitchGun(hit.transform.GetComponent<GunPickup>().gun);
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

    public void SwitchGun(GameObject g)
    {
        Destroy(gun);
        gun = null;
        GameObject newGun = Instantiate(g, transform.position, transform.rotation);
        gun = newGun;
        gun.transform.parent = transform;
        gun.GetComponent<Gun>().fpsCam = GetComponent<Camera>();
        if (pickupPrefab)
        {
            Instantiate(pickupPrefab, transform.position, transform.rotation);
        }
        pickupPrefab = gun.GetComponent<Gun>().Config.pickupPrefab;
        Debug.Log("GUN SWITCHED");
    }
}
