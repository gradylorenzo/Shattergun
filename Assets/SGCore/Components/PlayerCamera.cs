using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private Transform anchor;

    private Quaternion masterLookRotation;
    private Quaternion offsetLookRotation;
    private Quaternion defaultLookRotation = Quaternion.Euler(0, 0, 0);
    private Quaternion finalLookRotation;
    public float offsetDamping = 1.0f;

    private void Start()
    {
        anchor = transform.parent;
    }

    private void FixedUpdate()
    {
        //Set master look rotation ot the rotation of our parent;
        masterLookRotation = anchor.rotation;

        //Slowly zero out the offset rotation
        offsetLookRotation = Quaternion.RotateTowards(offsetLookRotation, defaultLookRotation, offsetDamping);

        //Add the master rotation and offset together for the final rotation
        finalLookRotation = Quaternion.Euler(offsetLookRotation.eulerAngles + masterLookRotation.eulerAngles);

        transform.rotation = finalLookRotation;
    }

    public void Bump(Vector2 force)
    {
        float xForce = -force.x;
        float yForce = Mathf.Sin(Time.time) * force.y;
        Quaternion newOffsetRotation = Quaternion.Euler(xForce, yForce, 0);
        offsetLookRotation = Quaternion.Euler(offsetLookRotation.eulerAngles + newOffsetRotation.eulerAngles);
        Debug.Log("Bumped with force of " + force);
    }
}
