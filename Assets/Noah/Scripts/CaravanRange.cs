﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanRange : MonoBehaviour
{
    private Rigidbody2D rb2;
    private Transform player;
    public float lineOfSite;

    public CaravanMove mov;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2 = GetComponent<Rigidbody2D>();
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
            mov.enabled = true;
        }
        else
        {
            mov.enabled = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}
