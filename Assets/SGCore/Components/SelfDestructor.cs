using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {

    public float delay;

    private float start;

    private void Start()
    {
        start = Time.time;
    }

    void Update ()
    {
		if(Time.time > start + delay)
        {
            Destroy(gameObject);
        }
	}
}
