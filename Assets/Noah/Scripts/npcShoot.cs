using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class npcShoot : MonoBehaviour
{
    public float speed;
    private Transform Enemy;
    public float lineOfSite;
    public float shootingRange;
    public GameObject enemyBullet;
    public Transform enemyBulletParent;
    public float fireRate = 1f;
    private float nextFireTime;

    public float bulletForce = 20f;

    public int health;
    public int maxHealth = 3;
    //public HealthBar healthBar;

    private GameObject[] multipleEnemies;
    public bool enemyContact;

    public int bulletCount;
    public int maxBulletCount = 30;

    public Version2AIDestinationSetter v2;
    public Version3AIDestinationSetter v3;

    // Start is called before the first frame update
    void Start()
    {
        bulletCount = maxBulletCount;
        health = maxHealth;
        Enemy = null;
        enemyContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        Enemy = FindClosestNPC();
        Vector3 targ = Enemy.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float distanceFromTarget = Vector2.Distance(Enemy.position, transform.position);
        if (distanceFromTarget < lineOfSite)
        {
            //Destination.enabled = false;
            //Path.enabled = false;
            //Move.enabled = false;
            //Seek.enabled = false;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
            //Destination.target = GameObject.FindWithTag("Enemy").transform;
            //if (ai.reachedEndOfPath = true)
            //{
            //    Shoot();
            //}

            if (nextFireTime < Time.time && bulletCount > 0)
            {
                nextFireTime = Time.time + fireRate;
                Shoot();
            }
        }
        //if(distanceFromTarget > lineOfSite)
        //{
        //    //Destination.enabled = true;
        //    //Path.enabled = true;
        //    //Move.enabled = true;
        //    //Seek.enabled = true;
        //    Destination.target = GameObject.FindWithTag("Player").transform;
        //}
        if (distanceFromTarget < shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Enemy.position, -1 * speed * Time.deltaTime);
        }
        if (bulletCount <= 0)
        {
            v2.enabled = false;
            v3.enabled = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(enemyBullet, enemyBulletParent.position, enemyBulletParent.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(enemyBulletParent.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
        bulletCount--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            //healthBar.SetHealth(health);
        }
        if(collision.gameObject.tag == "Caravan" && bulletCount <= 0)
        {
            bulletCount = maxBulletCount;
        }
    }

    Transform FindClosestNPC()
    {
        multipleEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleEnemies)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }
}
