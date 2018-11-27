using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootcrate : MonoBehaviour {

    public Animator anim;
    private bool isOpen = false;
    public Transform lootSpawnPosition;
    public GameObject[] possibleLoot;


    public void Interact()
    {
        if (!isOpen)
        {
            isOpen = true;
            Debug.Log("LOOTBOX OPENED");
            anim.SetBool("isOpen", true);

            int lootToSpawn = Random.Range(0, possibleLoot.Length);
            Instantiate(possibleLoot[lootToSpawn], lootSpawnPosition.position, lootSpawnPosition.rotation);
        }
    }
}
