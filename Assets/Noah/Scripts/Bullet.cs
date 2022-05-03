using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject hitEffect;
    public GameObject objectHitEffect;
    public float effectLasting = 0.07f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectLasting);

        }
        else if (collision.gameObject.layer == 10)
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectLasting);

        }
        else
        {
            GameObject effect = Instantiate(objectHitEffect, transform.position, Quaternion.identity);
            Destroy(effect, effectLasting);

        }
        Destroy(gameObject);
    }

}
