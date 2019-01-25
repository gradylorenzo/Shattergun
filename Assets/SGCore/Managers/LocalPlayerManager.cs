using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalPlayerManager{

    #region Ammo Handling
    private static int _ammo = 100;
    public static int ammo
    {
        get { return _ammo; }
    }
    private static int maxAmmo = 1000;

    public static void UseAmmo(int amount)
    {
        if(_ammo > amount)
        {
            _ammo -= amount;
        }
        else
        {
            _ammo = 0;
        }
        Debug.Log("Ammo Remaining: " + _ammo);
    }
    public static void AddAmmo(int amount)
    {
        if(_ammo + amount < maxAmmo)
        {
            _ammo += amount;
        }
        else
        {
            _ammo = maxAmmo;
        }
    }

    internal static void DrainAmmo()
    {
        _ammo = 0;
    }
    #endregion
}
