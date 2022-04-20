using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class WallHealth : MonoBehaviour
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            //healthBar.SetHealth(health);

        }
    }
}

