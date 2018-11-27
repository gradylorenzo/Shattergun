using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float health = 50f;
    public bool isExplosive = false;
    public float ExplosionDelay = 5.0f;
    public GameObject hitEffect;
    public GameObject destroyedObject;

    private bool hasBeenHit = false;
    private float timeOfFirstHit = 0;

    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    public void Damage(float amount, Vector3 hitPosition, Vector3 hitNormal)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        if (isExplosive)
        {
            if (hitEffect != null)
            {
                GameObject hE = Instantiate(hitEffect, hitPosition, Quaternion.LookRotation(hitNormal));
                hE.transform.parent = transform;
            }

            if (!hasBeenHit)
            {
                hasBeenHit = true;
                timeOfFirstHit = Time.time;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killplane")
        {
            Die();
        }
    }

    private void Update()
    {
        if(isExplosive && hasBeenHit)
        {
            if(Time.time > timeOfFirstHit + ExplosionDelay)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (destroyedObject != null)
        {
            Instantiate(destroyedObject, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
