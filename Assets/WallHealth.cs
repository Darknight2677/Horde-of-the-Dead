using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class WallHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 140;
    //public HealthBar healthBar;

    public void Start()
    {
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        GetComponent<BoxCollider2D>().enabled = true;
    }
    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 14)
        {
            health -= 2;
            //healthBar.SetHealth(health);
        }
        if (collision.gameObject.layer == 15)
        {
            health -= 1;
            //healthBar.SetHealth(health);
        }
        if (collision.gameObject.layer == 16)
        {
            health -= 4;
            //healthBar.SetHealth(health);
        }
        //if(collision.gameObject.tag == "Caravan" && bulletCount <= 0)
        //{
        //    bulletCount = maxBulletCount;
        //}

        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}

