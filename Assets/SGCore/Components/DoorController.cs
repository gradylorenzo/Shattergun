using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    [SerializeField]
    private Animator anim;

	public void ToggleDoor()
    {
        anim.SetBool("isOpen", !anim.GetBool("isOpen"));
    }
}
