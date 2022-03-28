using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    //public float speed;
    private Transform NPC;
    public float attackRange;
    public float attackRate = 1f;
    private float nextAttackTime;

    public float bulletForce = 20f;

    //public Transform attackPoint;

    public int health;
    public int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        NPC = GameObject.FindGameObjectWithTag("NPC").transform;
        Vector3 targ = NPC.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float distanceFromTarget = Vector2.Distance(NPC.position, transform.position);
        if (distanceFromTarget < attackRange)
        {
            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 270));
            //Destination.target = GameObject.FindWithTag("Enemy").transform;
            //if (ai.reachedEndOfPath = true)
            //{
            //    Shoot();
            //}

            if (nextAttackTime < Time.time)
            {
                nextAttackTime = Time.time + attackRate;
                StartCoroutine(Attack());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    IEnumerator Attack()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1f);
        GetComponent<BoxCollider2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
        }
    }
}