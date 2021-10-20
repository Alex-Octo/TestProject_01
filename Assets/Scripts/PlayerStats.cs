using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerMaxHp;
    public int currentHp; 
    public int playerMaxAmmo;
    public int currentAmmo;

    private void Awake()
    {
        playerMaxHp = 3;
        currentHp = playerMaxHp;
        playerMaxAmmo = 5;
        currentAmmo = playerMaxAmmo;
    }

    public void LoseAmmo(int ammo)
    {
        if (currentAmmo > 0)
            currentAmmo -= ammo;
    }
    public void AddAmmo(int ammo)
    {
        if (currentAmmo < playerMaxAmmo)
            currentAmmo += ammo;
    }

    public void LoseHealth(int hp)
    {
        currentHp -= hp;
        if(currentHp <= 0)
            print("Game is Over");
    }
}
