using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : MonoBehaviour {

    [SerializeField]
    private Animator DoorAnimator;
    public float delay;
    private float openTime;

    public void Interact()
    {
        if(DoorAnimator != null)
        {
            ToggleDoor();
        }
        else
        {
            Debug.Log("No Door Assigned");
        }
    }

    public void ToggleDoor()
    {
        openTime = Time.time;
        DoorAnimator.SetBool("isOpen", !DoorAnimator.GetBool("isOpen"));
    }
}
