using System.Collections.Generic;
using UnityEngine;

public class LoopManager : MonoBehaviour
{
    public static LoopManager instance; // singleton

    [Header("Floor")]
    public List<Floor> anomalies;
    public Floor defaultFloor;
    public Floor prevFloor = null;

    [Header("Room")]
    public int currentRoom = 7;
    const int startRoom = 7;
    private int normalRooms = 0;

    private void Awake()
    {
        instance = this; // singleton
    }

    private bool IsAnomaly() // we call this before spawn a room to know new room is anoaly or not
    {
        float chance = 0.30f + (normalRooms * 0.1f);
        chance = Mathf.Min(chance, 1f); // if number is bigger than 1 return 1
        bool anomaly = Random.value < chance;

        if (anomaly) normalRooms = 0;
        else normalRooms += 1;

        return anomaly;
    }

    public void LevelCheck() // check player pased right way or no
    {
        if (true) // player pased right way
        {
            currentRoom -= 1;
        } else // player pased wrong way
        {
            // currentRoom = startRoom;
        }
    }

    public void GenerateNextFloor()
    {
        // disable prev floor
        prevFloor.DisableFloor();

        if (IsAnomaly()) // spawn a anomaly level
        {
            SpawnAnomaly();
        } else // spawn default level
        {
            defaultFloor.EnableFloor();
            prevFloor = defaultFloor;
        }
    }

    public void GenerateCurrentFloor()
    {
        // do nothing
    }

    private void SpawnAnomaly()
    {
        int randIndex = Random.Range(0, anomalies.Count); // select an anomaly group randomly to spawn(enable)

        // enable selected anomaly
        anomalies[randIndex].EnableFloor();
        prevFloor = anomalies[randIndex];
    }
}
