using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CaravanPathFindingRange : MonoBehaviour
{
    private Rigidbody2D rb2;
    private Transform player;
    public float lineOfSite;

    private AIPath ai;
    private Version4AIDestinationSetter v4;
    private EnemyMovement mov;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2 = GetComponent<Rigidbody2D>();
        ai = GetComponent<AIPath>();
        v4 = GetComponent<Version4AIDestinationSetter>();
        mov = GetComponent<EnemyMovement>();
        //mov.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targ = player.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            ai.enabled = true;
            v4.enabled = true;
            mov.enabled = true;
        }
        else
        {
            ai.enabled = false;
            v4.enabled = false;
            mov.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}

