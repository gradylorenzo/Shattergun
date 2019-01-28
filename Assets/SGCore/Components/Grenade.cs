using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : MonoBehaviour {

    public float delay = 5.0f;
    public float blastRadius;
    public float blastPower;
    public GameObject explosion;
    public float throwingForce;
    private float startTime;
    
    private void Start()
    {
        startTime = Time.time;
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * throwingForce);
    }

    private void Update()
    {
        if (Time.time > startTime + delay)
        {
            Detonate();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Detonate()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
