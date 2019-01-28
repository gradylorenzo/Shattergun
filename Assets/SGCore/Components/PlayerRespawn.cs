using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    private Vector3 respawnPoint;

    private void Start()
    {
        //This should eventually be built to only run if this Player is owned by this client
        gameObject.tag = "Player";
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
        Debug.Log("RESPAWNING PLAYER");
    }

    public void SetRespawnPoint (Vector3 position)
    {
        respawnPoint = position;
        Debug.Log("RESPAWN POINT SET");
    }
}
