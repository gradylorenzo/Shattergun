using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lootcrate : MonoBehaviour {

    public Animator anim;
    private bool isOpen = false;
    public Transform[] lootSpawnPositions;
    public GameObject[] possibleLoot;


    public void Interact()
    {
        if (!isOpen)
        {
            foreach (Transform pos in lootSpawnPositions)
            {
                isOpen = true;
                Debug.Log("LOOTBOX OPENED");
                anim.SetBool("isOpen", true);

                int lootToSpawn = Random.Range(0, possibleLoot.Length);
                Instantiate(possibleLoot[lootToSpawn], pos.position, pos.rotation);
            }
        }
    }
}
