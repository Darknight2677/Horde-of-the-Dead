using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public int bulletCount;
    public int maxBulletCount = 30;
    public TMP_Text CurrentBullets;

    private bool reloading;

    private float nextFireTime;
    public float fireRate = 1f;

    //private FireAnimation FA;

    //public Text MaxBullets;
    void Start()
    {

        //FA = gameObject.GetComponent<FireAnimation>();

        bulletCount = maxBulletCount;

    }
    //public int damage = 40;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        CurrentBullets.text = bulletCount.ToString();
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(Reload());
        }

        void Shoot()
        {
            if (bulletCount > 0 && reloading == false && nextFireTime < Time.time)
            {
                //FA.anim.SetBool("Shoot", true);
                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
                Destroy(bullet, 5f);
                bulletCount--;

                nextFireTime = Time.time + fireRate;
            }


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

        IEnumerator Reload()
        {
            reloading = true;
            yield return new WaitForSeconds(1.5f);
            bulletCount = maxBulletCount;
            reloading = false;
        }
    }
}
