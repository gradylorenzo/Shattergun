using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingStation : MonoBehaviour {

    public float HealingRate = 1.0f;
    public float RepairRate = 0.0f;

    private GameObject player = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player = other.gameObject;
            Debug.Log("Player Entered!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player = null;
        }
    }

    public void FixedUpdate()
    {
        if(player != null)
        {
            player.SendMessage("RepairHealth", HealingRate);
            player.SendMessage("RepairSheild", RepairRate);
        }
    }
}
