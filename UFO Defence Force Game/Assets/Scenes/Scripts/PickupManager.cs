using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    
    public GameObject[] pickupPrefabs;
    [SerializeField]
    private float spawnRangeX = 20.0f;
    [SerializeField]
    private float spawnPosZ;
    private float startDelay = 3f;
    private float spawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPickup", startDelay, spawnInterval);
    }
    
    void SpawnRandomPickup()
    {
        //Generate a position to spawn at on the x-axis
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX),0, spawnPosZ);
        //Pick a random enemy/ ufo from the array
        int pickupIndex = Random.Range(0,pickupPrefabs.Length);
        //Spawn the enemy indexed from the array
        Instantiate(pickupPrefabs[pickupIndex], spawnPos, pickupPrefabs[pickupIndex].transform.rotation);
    }
}
