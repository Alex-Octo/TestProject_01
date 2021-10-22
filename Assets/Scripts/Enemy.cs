using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBullet enemyBulletPref;
    public SpawnManager spawnManager; 

    public float minSpeed;
    public float maxSpeed;
    public float minFireRate;
    public float maxFireRate; 
    public float minTurningTime;
    public float maxTurningTime; 

    public float currentSpeed;
    public float currentFireRate;
    public float currentTurningTime; //время смены параметров

    private void Start()
    {
        ChangeActions();
    }

    private void ChangeActions()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        currentFireRate = Random.Range(minFireRate, maxFireRate);
        currentTurningTime = Random.Range(minTurningTime, maxTurningTime);
        transform.Rotate(0, 0, Random.Range(0, 360));
        ChangeFireRate();
        Invoke("ChangeActions", currentTurningTime);
    }

    private void ChangeFireRate()
    {
        CancelInvoke("Shoot");
        InvokeRepeating("Shoot", 0, currentFireRate);
    }

    private void Shoot()
    {
        EnemyBullet bullet = Instantiate(enemyBulletPref, transform.position, transform.rotation); 
        bullet.rb.AddForce(transform.up * 400); 
    }

    private void ChangeDirection()
    {
        transform.Rotate(0, 0, Random.Range(120, 240));
    }

    private void FixedUpdate() 
    {
        transform.position += transform.up * Time.fixedDeltaTime * currentSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.transform.tag == "Bullet")
        {
            spawnManager.enemiesCount -= 1;
            spawnManager.respawnTimer -= 0.1f;
            spawnManager.StartEnemyCreation();         
            Destroy(gameObject);
        }
        else
            ChangeDirection();
    }

}
