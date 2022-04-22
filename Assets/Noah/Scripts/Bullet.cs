using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public GameObject objectHitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
        }
        else if (collision.gameObject.tag == "NPC")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
        }
        else if (collision.gameObject.tag == "Player")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
        }
        else
        {
            GameObject effect = Instantiate(objectHitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
        }
        Destroy(gameObject);
    }

}
