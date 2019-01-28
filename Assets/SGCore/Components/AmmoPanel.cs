using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPanel : MonoBehaviour {

    public Text weaponAmmo;
    public Text storedAmmo;
    public Text grenades;
    public Image healthbar;
    public Image shieldbar;
    public Text gunName;

    private void Awake()
    {
        EventManager.AmmoInWeaponChanged += AmmoInWeaponChanged;
        EventManager.AmmoInStorageChanged += AmmoInStorageChanged;
        EventManager.AmmoInStorageIncreased += AmmoInStorageIncreased;
        EventManager.AmmoInStorageDecreased += AmmoInStorageDecreased;
        EventManager.GrenadesChanged += GrenadesChanged;
        EventManager.GrenadesDecreased += GrenadesIncreased;
        EventManager.GrenadesIncreased += GrenadesIncreased;
        EventManager.HealthChanged += HealthChanged;
        EventManager.ShieldChanged += ShieldChanged;
        EventManager.GunChanged += GunChanged;
    }

    private void AmmoInWeaponChanged(int a)
    {
        weaponAmmo.text = a.ToString();
    }

    private void AmmoInStorageChanged(int a)
    {
        storedAmmo.text = a.ToString();
    }

    private void AmmoInStorageIncreased(int a)
    {
        storedAmmo.text = a.ToString();
        storedAmmo.GetComponent<Animator>().Play("increased");
    }

    private void AmmoInStorageDecreased(int a)
    {
        storedAmmo.text = a.ToString();
        storedAmmo.GetComponent<Animator>().Play("decreased");
    }

    private void GrenadesChanged(int a)
    {
        grenades.text = a.ToString();
    }

    private void GrenadesIncreased (int a)
    {
        grenades.text = a.ToString();
        grenades.GetComponent<Animator>().Play("increased");
    }

    private void GrenadesDecreased (int a)
    {
        grenades.text = a.ToString();
        grenades.GetComponent<Animator>().Play("decreased");
    }

    private void HealthChanged(float a)
    {
        healthbar.fillAmount = a;
        healthbar.GetComponent<Animator>().SetBool("isLow", (a < 0.5f));
        Debug.Log("Health Changed: " + a.ToString());
    }

    private void ShieldChanged(float a)
    {
        shieldbar.fillAmount = a;
        Debug.Log("Shield Changed: " + a.ToString());
    }

    private void GunChanged (string name)
    {
        gunName.text = name;
    }
}
