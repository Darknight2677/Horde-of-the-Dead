﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemyAI : MonoBehaviour
//{
//    public float speed;
//    public float checkRadius;
//    public float attackRadius;

//    public bool shouldRotate;

//    public LayerMask whatIsTarget;

//    private Transform player;
//    private Transform target;
//    private Rigidbody2D rb;
//    private Animator anim;
//    private Vector2 movement;
//    public Vector3 dir;

//    private bool isInChaseRange;
//    private bool isInAttackRange;

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        anim = GetComponent<Animator>();
//        target = GameObject.FindWithTag("NPC").transform;
//        player = GameObject.FindWithTag("Player").transform;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        anim.SetBool("isRunning", isInChaseRange);

//        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsTarget);
//        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsTarget);

//        dir = target.position - transform.position;
//        float angle =- Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
//        dir.Normalize();
//        movement = dir;
//        if (shouldRotate)
//        {
//            anim.SetFloat("X", dir.x);
//            anim.SetFloat("Y", dir.y);
//        }

//    }

//    private void FixedUpdate()
//    {
//        if(isInChaseRange && !isInAttackRange)
//        {
//            MoveCharacter(movement);
//        }
//        if (isInAttackRange)
//        {
//            rb.velocity =- Vector2.zero;
//        }
//    }

//    private void MoveCharacter(Vector2 dir)
//    {
//        rb.MovePosition(Vector2)transform.position + (dir * speed * Time.deltaTime);
//    }
//}