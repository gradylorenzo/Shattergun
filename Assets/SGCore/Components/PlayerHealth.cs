using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth;
    public float HealthRechargeDelay;
    public float HealthRechargeRate;
    private float timeOfLastHit;

    private void Start()
    {
        currentHealth = maxHealth;
        EventManager.HealthChanged(1);
    }

    public void TakeDamage(int d)
    {
        
        timeOfLastHit = Time.time;
        currentHealth -= d;
        float h = currentHealth / maxHealth;

        EventManager.HealthChanged(h);
    }

    public void RepairHealth(float a)
    {
        currentHealth = Mathf.Clamp(currentHealth + a, 0, maxHealth);
        float h = currentHealth / maxHealth;
        EventManager.HealthChanged(h);
    }

    private void FixedUpdate()
    {
        if (currentHealth < maxHealth)
        {
            if (Time.time > timeOfLastHit + HealthRechargeDelay)
            {
                RepairHealth(HealthRechargeRate);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(25);
        }
    }
}
