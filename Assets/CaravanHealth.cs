using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class CaravanHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    //public HealthBar healthBar;

    public void Start()
    {
        health = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }
    // Update is called once per frame
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("MainMenuScene");
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
    }
}
