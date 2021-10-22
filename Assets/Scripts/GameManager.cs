using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text finalText;

    public PlayerController playerController;
    public PlayerStats playerStats;
    public SpawnManager spawnManager;
    public Enemy enemy;

    public int playerMaxHp = 3;
    public int playerMaxAmmo = 5;
    public float playerMoveSpeed = 1;
    public float playerTurnSpeed = 0.1f;
    public float playerShootForce = 400f;
    public float enemyMinSpeed = 0.1f; 
    public float enemyMaxSpeed = 1.5f;
    public float enemyMinFireRate = 0.5f;
    public float enemyMaxFireRate = 3f;
    public float enemyMinTurningTime = 1f;
    public float enemyMaxTurningTime = 8f;
    public float respawnTimer = 3f;
    public int enemiesNumber = 25;

    private void Awake() 
    {
        playerController = playerController.GetComponent<PlayerController>();
        playerStats = playerStats.GetComponent<PlayerStats>();
        spawnManager = spawnManager.GetComponent<SpawnManager>();
        enemy = enemy.GetComponent<Enemy>();

        playerStats.playerMaxHp = playerMaxHp;
        playerStats.playerMaxAmmo = playerMaxAmmo;
        playerController.moveSpeed = playerMoveSpeed;
        playerController.turnSpeed = playerTurnSpeed;
        playerController.shootForce = playerShootForce;

        enemy.minSpeed = enemyMinSpeed;
        enemy.maxSpeed = enemyMaxSpeed;
        enemy.minFireRate = enemyMinFireRate;
        enemy.maxFireRate = enemyMaxFireRate;
        enemy.minTurningTime = enemyMinTurningTime;
        enemy.maxTurningTime = enemyMaxTurningTime;

        spawnManager.respawnTimer = respawnTimer;
        spawnManager.enemiesCount = enemiesNumber;
    }

    public void StartLoadingMenu(bool winner) 
    {
        if (winner)
            finalText.text = ("Поздравляю вы победили");
        else
            finalText.text = ("Проиграл");
        Invoke("LoadMenu", 3f);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level"); 
    }

}
