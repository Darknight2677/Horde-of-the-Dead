using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HordeCombat : MonoBehaviour
{
    //public float speed;
    private Transform NPC;
    //public float lineOfSite;
    public float attackRange;
    public float attackRate = 1f;
    private float nextAttackTime;

    //public Transform attackPoint;

    public int health;
    public int maxHealth = 3;

    private GameObject[] multipleNPCs;
    public bool npcContact;

    Animator anim;

    // Start is called before the first frame update
    public void Start()
    {
        health = maxHealth;
        NPC = null;
        npcContact = false;

        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //NPC = GameObject.FindGameObjectWithTag("NPC").transform;
        NPC = FindClosestNPC();
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
                anim.SetBool("Attacking", true);
            }
            else
            {
                anim.SetBool("Attacking", false);
            }
        }
    }

    private void LateUpdate()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        //Gizmos.DrawWireSphere(transform.position, lineOfSite);
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
            health -= 2;
        }
    }

    Transform FindClosestNPC()
    {
        multipleNPCs = GameObject.FindGameObjectsWithTag("NPC");
        float closestDistance = Mathf.Infinity;
        Transform trans = null;

        foreach (GameObject go in multipleNPCs)
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