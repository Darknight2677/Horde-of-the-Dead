using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAnimation : MonoBehaviour
{
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        //anim.SetBool("Shoot", false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //StartCoroutine(Shooting());
        //    anim.SetBool("Shoot", true);
        //}
        //else
        //{
        //    anim.SetBool("Shoot", false);
        //}
    }

    //IEnumerator Shooting()
    //{
    //    anim.SetBool("Shoot", true);
    //    yield return new WaitForSeconds(10f);
    //    anim.SetBool("Shoot", false);
    //}
}
