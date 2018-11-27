using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public int dungeonSize = 10;
    public GameObject[] rooms;

    private int currentRoom = 0;
    private Vector3 currentPosition;
    private bool complete = false;

    private void Start()
    {
        currentPosition = Vector3.zero;
    }

    private void Update()
    {
        if(currentRoom <= dungeonSize)
        {
            int room = Random.RandomRange(0, rooms.Length);
            Debug.Log("INSTANTIATING NEW ROOM AT POSITION   " + currentPosition.x + "   |   " + currentPosition.y + "   |   " + currentPosition.z);
            GameObject newRoom = Instantiate(rooms[room], currentPosition, transform.rotation);
            currentPosition += newRoom.GetComponent<RoomInfo>().endPoint;
            currentRoom++;
        }
        else if(!complete)
        {
            //This should call an event once the Event Manager is implemented
            Debug.Log("GENERATED DUNGEON WITH " + currentRoom + " ROOMS");
            complete = true;
        }
    }
}
