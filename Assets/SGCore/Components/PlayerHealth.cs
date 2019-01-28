using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth = 100;
    public float maxShield = 100;
    public float currentHealth;
    public float currentShield;
    public float ShieldRechargeDelay;
    public float ShieldRechargeRate;
    private float timeOfLastHit;

    private void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
        EventManager.HealthChanged(1);
        EventManager.ShieldChanged(1);
    }

    public void TakeDamage(int d)
    {
        float remainingDamage = 0;

        if(d < currentShield)
        {
            currentShield -= d;
        }
        else
        {
            remainingDamage = d - currentShield;
            currentShield = 0;
            currentHealth -= remainingDamage;
        }
        timeOfLastHit = Time.time;

        float h = currentHealth / maxHealth;
        float s = currentShield / maxShield;

        EventManager.HealthChanged(h);
        EventManager.ShieldChanged(s);
    }

    public void RepairSheild(float a)
    {
        currentShield = Mathf.Clamp(currentShield + a, 0, maxShield);
        float s = currentShield / maxShield;
        EventManager.ShieldChanged(s);
    }

    public void RepairHealth(float a)
    {
        currentHealth = Mathf.Clamp(currentHealth + a, 0, maxHealth);
        float h = currentHealth / maxHealth;
        EventManager.HealthChanged(h);
    }

    private void FixedUpdate()
    {
        if(Time.time > timeOfLastHit + ShieldRechargeDelay && currentShield < maxShield)
        {
            currentShield = Mathf.Clamp(currentShield + ShieldRechargeRate, 0, maxShield);
            float s = currentShield / maxShield;
            EventManager.ShieldChanged(s);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(25);
        }
    }
}
