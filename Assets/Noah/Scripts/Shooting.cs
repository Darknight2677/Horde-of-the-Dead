using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    //public int damage = 40;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 5f);

        //RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        //if (hitInfo)
        //{
        //    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
        //    if (enemy != null)
        //    {
        //        enemy.TakeDamage(damage);
        //    }
        //}
    }
}
