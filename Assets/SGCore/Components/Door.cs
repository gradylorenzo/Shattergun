using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Animator anim;
    private bool isOpen = false;

    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("BLAST DOOR OPENED");
            anim.SetBool("isOpen", true);
        }
    }
}
