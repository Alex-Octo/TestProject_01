using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpawnManager spawnManager;
    public GameManager gameManager;
    public int playerMaxHp;
    public int currentHp; 
    public int playerMaxAmmo;
    public int currentAmmo;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        spawnManager = spawnManager.GetComponent<SpawnManager>();
        gameManager = gameManager.GetComponent<GameManager>(); 
        currentHp = playerMaxHp;
        currentAmmo = playerMaxAmmo;
    }

    public void LoseAmmo(int ammo)
    {
        if (currentAmmo > 0)
        {
            currentAmmo -= ammo;
            gameManager.ammoText.text = currentAmmo.ToString();
        }
    }
    public void AddAmmo(int ammo)
    {
        if (currentAmmo < playerMaxAmmo)
        {
            currentAmmo += ammo;
            gameManager.ammoText.text = currentAmmo.ToString();
        }
    }

    public void LoseHealth(int hp)
    {
        currentHp -= hp;
        if (currentHp <= 0)
        {
            gameManager.healthText.text = 0.ToString();
            gameManager.StartLoadingMenu(false);
            gameObject.SetActive(false);
        }
        else
        {
            gameManager.healthText.text = currentHp.ToString();
            rb.velocity = Vector2.zero;
            spawnManager.RespawnHero();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemyBullet")
            LoseHealth(1);
        else if (collision.transform.tag == "Enemy")
            LoseHealth(1);
    }
}
