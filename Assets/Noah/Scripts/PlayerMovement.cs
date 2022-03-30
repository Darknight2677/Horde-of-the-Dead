using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;
    Animator anim;

    Vector2 movement;
    Vector2 mousePos;

    //public int health;
    //public int maxHealth = 3;
   // public HealthBar healthBar;

    public void Start()
    {
        //health = maxHealth;
        anim = gameObject.GetComponent<Animator>();
        //healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else anim.SetBool("IsWalking", false);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        health--;
    //        healthBar.SetHealth(health);
    //    }
    //}
}

