﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Rigidbody2D rb2;
    public float speed;
    private Transform target;
    public float lineOfSite;
    public float shootingRange;
    public GameObject enemyBullet;
    public GameObject enemyBulletParent;
    public float fireRate = 1f;
    private float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Enemy").transform;
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targ = target.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));

        float distanceFromTarget = Vector2.Distance(target.position, transform.position);
        if (distanceFromTarget < lineOfSite && distanceFromTarget > shootingRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, speed * Time.deltaTime);
        }
        else if (distanceFromTarget <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(enemyBullet, enemyBulletParent.transform.position, Quaternion.identity);
            enemyBullet.rotation == enemyBulletParent.rotation;
            nextFireTime = Time.time + fireRate;
        }

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}