using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : MonoBehaviour {

    public DoorController Door;

	public void Interact()
    {
        if(Door != null)
        {
            Door.ToggleDoor();
        }
        else
        {
            Debug.Log("No Door Assigned");
        }
    }
}
