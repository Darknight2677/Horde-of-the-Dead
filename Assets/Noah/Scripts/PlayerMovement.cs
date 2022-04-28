using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    float speedLimiter = 0.7f;

    public Rigidbody2D rb;
    public Camera cam;
    Animator anim;

    Vector2 movement;
    Vector2 mousePos;

    public int health;
    public int maxHealth = 3;
    public HealthBar healthBar;

    public int HordeDefeated = 0;
    public int HordeNeededToDefeat;

    public void Start()
    {
        health = maxHealth;
        anim = gameObject.GetComponent<Animator>();
        healthBar.SetMaxHealth(maxHealth);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (movement.x != 0 || movement.y != 0)
        {
            if (movement.x != 0 && movement.y != 0)
            {
                movement.x *= speedLimiter;
                movement.y *= speedLimiter;
            }
            anim.SetBool("IsWalking", true);
            rb.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
        }
        else
        {
            anim.SetBool("IsWalking", false);
            rb.velocity = new Vector2(0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenuScene");
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if(HordeDefeated == HordeNeededToDefeat)
        {
            SceneManager.LoadScene("MainMenuScene");
        }



    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            healthBar.SetHealth(health);

        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == 13)
    //    {
    //        Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    //    }
    //}
}

