using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public string killplaneTag = "Killplane";
    public string respawnTag = "Respawn";

    private Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == respawnTag)
        {
            respawnPoint = other.gameObject.transform;
            Debug.Log("RESPAWN POINT SET");
        }

        if(other.gameObject.tag == killplaneTag)
        {
            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                Debug.Log("RESPAWNING..");
            }
            else
            {
                Debug.Log("NO RESPAWN POINT FOUND");
            }
        }
    }
}
