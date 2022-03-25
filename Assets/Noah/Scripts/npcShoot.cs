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

    public Version2AIDestinationSetter Destination;
    public npcMovement Move;
    public AIPath Path;
    public Seeker Seek;

    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {
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

            if (nextFireTime < Time.time)
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
    }
}
