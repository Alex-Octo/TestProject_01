using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject playerObj; 
    private PlayerStats playerStats;

    private void Awake()
    {
        playerStats = playerObj.GetComponent<PlayerStats>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Bullet")
        {
            playerStats.AddAmmo(1);
        }
    }

}
