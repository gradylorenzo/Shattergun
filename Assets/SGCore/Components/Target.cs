using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {
    public float health = 50f;
    public GameObject destroyedObject;

    public void Damage(float amount)
    {
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Killplane")
        {
            Die();
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
