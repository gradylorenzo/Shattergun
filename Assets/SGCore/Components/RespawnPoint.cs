using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour {

    public List<GameObject> playersHit = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (playersHit.Contains(other.gameObject))
            {
                playersHit.Add(other.gameObject);
            }
        }

        //At some point, once two players are supported, a method needs to be added to get a dynamic player count.
        if(playersHit.Count == 1)
        {
            EventManager.AllPlayersMovedUp();
        }
    }
}
