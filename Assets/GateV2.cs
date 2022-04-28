using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateV2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            yield return new WaitForSeconds(5f);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(collision.gameObject.tag == "NPC")
    //    {

    //    }
    //}
}
