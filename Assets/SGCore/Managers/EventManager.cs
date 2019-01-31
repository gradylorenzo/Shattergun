using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void PlayerMovedUpEvent();
    public static PlayerMovedUpEvent AllPlayersMovedUp;

    public delegate void AmmoChangedEvent(int a);
    public static AmmoChangedEvent AmmoInWeaponChanged;
    public static AmmoChangedEvent AmmoInStorageChanged;
    public static AmmoChangedEvent AmmoInStorageIncreased;
    public static AmmoChangedEvent AmmoInStorageDecreased;
    public static AmmoChangedEvent GrenadesDecreased;
    public static AmmoChangedEvent GrenadesIncreased;
    public static AmmoChangedEvent GrenadesChanged;

    public delegate void HealthChangedEvent(float a);
    public static HealthChangedEvent HealthChanged;

    public delegate void TargetHitEvent();
    public static TargetHitEvent EnemyHit;

    public delegate void GunChangedEvent(string name);
    public static GunChangedEvent GunChanged;
}
