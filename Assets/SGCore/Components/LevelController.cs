using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [System.Serializable]
    public class LevelGeneration
    {
        public bool generateLevelAtStart = false; //This tells the scripts if a level needs to be generated when the game starts. This shopuld be turned off if you are testing a single room
        public GameObject[] RoomPrefabs; //This holds all room prefabs that can make up a level
        public int[] RoomsList; //This contains a number referring to each room prefab that makes up the level.
        public int LevelRoomCount = 10; //This tells the generator how many rooms the level should have
    }

    [System.Serializable]
    public class PlayerTracking
    {
        public int furthestRoomAccessed;
    }

    public LevelGeneration LGP;
    public PlayerTracking PT;

    public void Awake()
    {
    
    }

    private void Start()
    {
        if (LGP.generateLevelAtStart)
        {
            GenerateLevel();
        }
    }

    private void GenerateLevel()
    {
        List<int> roomList = new List<int>();
        for(int i = 0; i < LGP.LevelRoomCount; i++)
        {
            int e = UnityEngine.Random.Range(0, LGP.RoomPrefabs.Length);
            roomList.Add(e);
        }
        LGP.RoomsList = roomList.ToArray();
        Debug.Log("Level generated with " + LGP.LevelRoomCount + " rooms");
    }
}
