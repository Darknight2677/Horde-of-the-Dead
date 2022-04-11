﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{

    public AIPath aIPath;

    Vector2 direction;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        faceVelocity();

        if (aIPath.reachedEndOfPath == true)
        {
            anim.SetBool("IsWalking", false);
        }
        else
        {
            anim.SetBool("IsWalking", true);
        }
    }

    void faceVelocity()
    {
        //direction = aIPath.desiredVelocity;

        //transform.right = direction;
    }
}