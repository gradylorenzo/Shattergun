using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalPlayerManager {

    #region Ammo Handling
    private static int _ammo = 100;
    public static int ammo
    {
        get { return _ammo; }
    }
    private static int _maxAmmo = 1000;
    public static int maxAmmo
    {
        get { return _maxAmmo; }
    }

    private static int _grenades = 3;
    public static int grenades
    {
        get { return _grenades; }
    }

    private static int _maxGrenades = 3;
    public static int maxGrenades
    {
        get { return _maxGrenades; }
    }

    public static int ReloadAmmo(int a)
    {
        int i = 0;
        if(_ammo > a)
        {
            i = a;
            _ammo -= a;
        }
        else
        {
            i = _ammo;
            _ammo = 0;
        }
        EventManager.AmmoInStorageDecreased(_ammo);
        return i;
    }

    public static void StoreAmmo(int a)
    {
        _ammo = Mathf.Clamp(_ammo + a, 0, _maxAmmo);
        EventManager.AmmoInStorageIncreased(_ammo);
    }

    public static void UseGrenade()
    {
        if(_grenades > 0)
        {
            _grenades--;
            EventManager.GrenadesDecreased(_grenades);
        }
    }

    public static void StoreGrenades(int g)
    {
        if (_grenades < _maxGrenades)
        {
            _grenades++;
            EventManager.GrenadesIncreased(_grenades);
        }
    }
    #endregion
}
