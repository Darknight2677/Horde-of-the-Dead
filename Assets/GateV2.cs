using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GateV2 : MonoBehaviour
{
    public AIPath aIPath;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (aIPath.reachedEndOfPath == true)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "NPC")
    //    {

    //    }
    //}
}
