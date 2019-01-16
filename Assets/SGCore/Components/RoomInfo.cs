using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInfo : MonoBehaviour {

    public Vector3 endPoint;

    public void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position + endPoint, .1f);
    }
}
