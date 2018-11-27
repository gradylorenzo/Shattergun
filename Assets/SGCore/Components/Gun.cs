using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [Serializable]
    public struct GunConfiguration
    {
        public bool canADS;
        public float damage;
        public float range;
        public float rateOfFire;
        public float impactForce;
        public float recoilHipfire;
        public float recoilADS;
        public Vector3 hipfirePosition;
        public Vector3 ADSPosition;
        public Vector3 runningPosition;
        public GameObject pickupPrefab;
    }

    private bool CanUseGun = true;
    [SerializeField] private bool isADS = false;
    public bool ADSTest = false;

    public GunConfiguration Config;

    public Camera fpsCam;

    public float adsTransitionSpeed;

    private Vector3 wantedGunPosition;
    private Vector3 currentGunPosition;

    [SerializeField] private GameObject gunModel;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioSource gunSound;

    private float nextFire = 0f;

    private void Update()
    {
        if (CanUseGun)
        {
            if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0) && Time.time >= nextFire)
            {
                nextFire = Time.time + (1f / Config.rateOfFire);
                Shoot();
            }
            if (!ADSTest)
            {
                if (Config.canADS)
                    isADS = (Input.GetButton("ADS") || Input.GetAxis("ADS") > 0);
            }
            else
            {
                isADS = true;
            }


            if (!isADS)
            {
                wantedGunPosition = Config.hipfirePosition;
            }
            else
            {
                wantedGunPosition = Config.ADSPosition;
            }
            currentGunPosition = Vector3.MoveTowards(currentGunPosition, wantedGunPosition, adsTransitionSpeed);
            gunModel.transform.localPosition = currentGunPosition;
        }
    }

    private void Shoot()
    {
        muzzleFlash.Play();
        gunSound.Play();
        GetComponent<Animator>().Play("KICK");

        if (isADS)
        {
            fpsCam.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(-Config.recoilADS, 0, 0));
        }
        else
        {
            fpsCam.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(-Config.recoilHipfire, 0, 0));
        }

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Config.range))
        {
            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * Config.impactForce);
            }

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                Debug.Log("HIT GAMEOBJECT " + hit.transform.name + " : TARGET COMPONENT FOUND");
                if (target.isExplosive)
                {
                    target.Damage(Config.damage, hit.point, hit.normal);
                }
                else
                {
                    target.Damage(Config.damage);
                }
            }
            else
            {
                Debug.Log("HIT GAMEOBJECT " + hit.transform.name + " : TARGET COMPONENT NOT FOUND");
            }
        }
    }
}
