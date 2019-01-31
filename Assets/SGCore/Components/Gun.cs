using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour {
    

    [Serializable]
    public struct GunConfiguration
    {
        [Serializable]
        public enum FiringModes
        {
            semiauto,
            burstfire,
            fullauto
        }

        public string name;
        public bool canADS;
        public float ADSFOV;
        public FiringModes Mode;
        public int burstLength;
        public float pause;
        public float damage;
        public float range;
        public float rateOfFire;
        public float impactForce;
        public float reloadTime;
        public Vector2 recoilHipfire;
        public Vector2 recoilADS;
        public Vector3 hipfirePosition;
        public Vector3 ADSPosition;
        public Vector3 runningPosition;
        public GameObject pickupPrefab;
    }
    public int ammo = 20;
    public int maxAmmo = 20;
    private bool CanUseGun = true;

    [SerializeField] private bool isADS = false;
    public bool ADSTest = false;

    public GunConfiguration Config;
    public Camera fpsCam;

    [Header("ADS")]
    private float defaultFOV;
    private float wantedFOV;
    private float currentFOV;
    public float adsTransitionSpeed;

    private Vector3 wantedGunPosition;
    private Vector3 currentGunPosition;

    [SerializeField] private GameObject gunModel;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private AudioSource gunSound;
    [SerializeField] private AudioSource drySound;

    private float nextFire = 0f;

    private void Start()
    {
        fpsCam = transform.parent.GetComponent<Camera>();
        defaultFOV = 60;
        wantedFOV = defaultFOV;
        currentFOV = defaultFOV;
        EventManager.AmmoInWeaponChanged(ammo);
        EventManager.AmmoInStorageChanged(LocalPlayerManager.ammo);
    }

    private void Update()
    {
        if (CanUseGun)
        {
            if (Config.Mode == GunConfiguration.FiringModes.fullauto)
            {
                if ((Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0) && Time.time >= nextFire)
                {
                    nextFire = Time.time + (1f / Config.rateOfFire);
                    Shoot();
                }
            }
            else if(Config.Mode == GunConfiguration.FiringModes.semiauto)
            {
                if (((Input.GetButtonDown("Fire1") || (Input.GetAxis("Fire1") > 0)) && Time.time >= nextFire))
                {
                    nextFire = Time.time + Config.pause;
                    Shoot();
                }
            }
            else if(Config.Mode == GunConfiguration.FiringModes.burstfire)
            {

            }

            if (Input.GetButtonDown("Reload"))
            {
                StartCoroutine("Reload");
            }
        }

        ADS();
    }

    private void ADS()
    {
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
            wantedFOV = defaultFOV;
        }
        else
        {
            wantedGunPosition = Config.ADSPosition;
            wantedFOV = Config.ADSFOV;
        }

        currentFOV = Mathf.MoveTowards(currentFOV, wantedFOV, adsTransitionSpeed * 50);
        fpsCam.fieldOfView = currentFOV;
        currentGunPosition = Vector3.MoveTowards(currentGunPosition, wantedGunPosition, adsTransitionSpeed);
        gunModel.transform.localPosition = currentGunPosition;
    }

    private void Shoot()
    {
        if (ammo > 0)
        {
            muzzleFlash.Play();
            gunSound.Play();
            //GetComponent<Animator>().Play("KICK");

            if (isADS)
            {
                fpsCam.SendMessage("Bump", Config.recoilADS);
            }
            else
            {
                fpsCam.SendMessage("Bump", Config.recoilHipfire);
            }

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Config.range))
            {
                if (hit.rigidbody != null)
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

                    if (target.isEnemy)
                    {
                        EventManager.EnemyHit();
                    }
                }
                else
                {
                    Debug.Log("HIT GAMEOBJECT " + hit.transform.name + " : TARGET COMPONENT NOT FOUND");
                }
            }
            ammo -= 1;
            EventManager.AmmoInWeaponChanged(ammo);
        }
        else
        {
            drySound.Play();
            StartCoroutine("Reload");
        }
    }

    private IEnumerator Reload()
    {
        if (LocalPlayerManager.ammo> 0)
        {
            CanUseGun = false;
            yield return new WaitForSeconds(Config.reloadTime);
            int neededAmmo = maxAmmo - ammo;
            ammo += LocalPlayerManager.ReloadAmmo(neededAmmo);
            EventManager.AmmoInWeaponChanged(ammo);
            CanUseGun = true;
        }
    }
}
