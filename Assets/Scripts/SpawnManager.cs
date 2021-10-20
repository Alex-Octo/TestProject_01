using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Vector2[] spawnPositions;

    private void Awake()
    {
        spawnPositions = new Vector2[spawnObjects.Length];
        for(int i = 0; i<spawnObjects.Length; i++)
        {
            spawnPositions[i] = spawnObjects[i].transform.position;
        }
    }
}
