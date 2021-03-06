using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPC : MonoBehaviour
{
    //private Rigidbody2D rb2;
    public float speed;
    private Transform Target;
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
        Target = GameObject.FindGameObjectWithTag("Enemy").transform;
        //rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targ = Target.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        //float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));

        float distanceFromTarget = Vector2.Distance(Target.position, transform.position);
        if (distanceFromTarget < lineOfSite && distanceFromTarget > shootingRange)
        {
            //Destination.enabled = false;
            //Path.enabled = false;
            //Move.enabled = false;
            //Seek.enabled = false;
            Destination.target = GameObject.FindWithTag("Enemy").transform;
        }
        else if (distanceFromTarget <= shootingRange && nextFireTime < Time.time)
        {
            Destination.enabled = false;
            Path.enabled = false;
            Move.enabled = false;
            Seek.enabled = false;
            nextFireTime = Time.time + fireRate;

            Shoot();
        }
        else
        {
            Destination.enabled = true;
            Path.enabled = true;
            Move.enabled = true;
            Seek.enabled = true;
            Destination.target = GameObject.FindWithTag("Player").transform;
        }
        //else if(distanceFromTarget < shootingRange)
        //{
        //    transform.position = Vector2.MoveTowards(this.transform.position, target.position, -1 * speed * Time.deltaTime);
        //}
        //else
        //{
        //    Destination.enabled = true;
        //    Path.enabled = true;
        //    Move.enabled = true;
        //    Seeker.enabled = true;
        //}

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