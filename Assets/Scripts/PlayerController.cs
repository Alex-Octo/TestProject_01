using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Bullet bulletPref;
    private PlayerStats playerStats;
    public float moveSpeed;
    public float turnSpeed;
    public float shootForce;

    Vector2 mouseScreenPos;
    Vector2 mouseDirection;
    Vector2 savedMousePos;
    public bool mouseControllActive;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerStats = gameObject.GetComponent<PlayerStats>();
        moveSpeed = 1f;
        turnSpeed = 0.1f;
        shootForce = 500f;
        savedMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        mouseScreenPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mouseScreenPos - (Vector2)transform.position);

        if (mouseScreenPos != savedMousePos)
        {
            mouseControllActive = true;
            savedMousePos = mouseScreenPos;
        }
        else
            mouseControllActive = false;

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (playerStats.currentAmmo > 0)
            {
                Bullet bullet = Instantiate(bulletPref, transform.position, transform.rotation);
                bullet.rb.AddForce(transform.up * shootForce);
                playerStats.LoseAmmo(1);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!mouseControllActive)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                rb.AddTorque(1f * turnSpeed);
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                rb.AddTorque(-1f * turnSpeed);
        }
        else
            transform.up = mouseDirection;

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            rb.AddForce(transform.up * moveSpeed);
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.up * moveSpeed/2);
    }
}
