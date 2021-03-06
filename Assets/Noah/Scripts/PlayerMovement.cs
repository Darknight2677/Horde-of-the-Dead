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

        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.S))
        {
            this.gameObject.transform.position = new Vector3(10.7f, -153.38f, 0);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.Z))
        {
            SceneManager.LoadScene("Victory Scene");
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("Closing Scene");
        }

        if(HordeDefeated == HordeNeededToDefeat)
        {
            SceneManager.LoadScene("Victory Scene");
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
        if (collision.gameObject.layer == 14)
        {
            health -= 2;
            healthBar.SetHealth(health);
        }
        if (collision.gameObject.layer == 15)
        {
            health -= 1;
            healthBar.SetHealth(health);
        }
        if (collision.gameObject.layer == 16)
        {
            health -= 4;
            healthBar.SetHealth(health);
        }

        if (collision.gameObject.tag == "HealthPack")
        {
            health = maxHealth;
            healthBar.SetHealth(maxHealth);
            Destroy(collision.gameObject);
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

