using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;
    public float rateOfFire = 15f;
    public float impactForce = 30.0f;
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    private float nextFire = 0f;

    private void Update()
    {
        if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0) && Time.time >= nextFire)
        {
            nextFire = Time.time + (1f / rateOfFire);
            Shoot();
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log("HIT GAMEOBJECT " + hit.transform.name + " : TARGET COMPONENT FOUND");
                target.Damage(damage);
            }
            else
            {
                Debug.Log("HIT GAMEOBJECT " + hit.transform.name + " : TARGET COMPONENT NOT FOUND");
            }
        }
    }
}
