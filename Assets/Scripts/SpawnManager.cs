using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjects;

    public GameManager gameManager;
    private SpawnManager spawnManager;
    public GameObject player;
    public Enemy enemyPref;
    private Vector3 creatingPos;
    public float respawnTimer;
    [HideInInspector] public int enemiesCount;
    public int enemiesCreated; // просто для удобства подсчета

    private void Start() 
    {
        gameManager = gameManager.GetComponent<GameManager>();
        spawnManager = GetComponent<SpawnManager>();
        Invoke("FirstFiveSpawn", 2f); 
    }

    public void StartEnemyCreation()
    {
        if (enemiesCount > 0)
        {
            Invoke("CreateEnemy", respawnTimer);
        }
        else if (enemiesCount <= -4)
            gameManager.StartLoadingMenu(true);
    }

    public void CreateEnemy()
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            if (spawnObjects[i].GetComponent<SpawnSpot>().busy == false)
            {
                creatingPos = spawnObjects[i].transform.position;
                Enemy enemy = Instantiate(enemyPref, creatingPos, Quaternion.identity);
                enemy.spawnManager = spawnManager;
                enemiesCreated += 1;
                break;
            }
        }      
    }

    private void FirstFiveSpawn()
    {
        enemiesCount -= 4;
        for (int i = 0; i < 5; i++)
        {           
            creatingPos = spawnObjects[i].transform.position;
            Enemy enemy = Instantiate(enemyPref, creatingPos, Quaternion.identity);
            enemy.spawnManager = spawnManager;
            enemiesCreated += 1;
        }
    }

    public void RespawnHero()
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            if (spawnObjects[i].GetComponent<SpawnSpot>().busy == false)
            {
                creatingPos = spawnObjects[i].transform.position;
                player.transform.position = creatingPos;
                break;
            }
        }
    }

}
