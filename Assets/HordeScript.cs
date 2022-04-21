using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeScript : MonoBehaviour
{
    private EnemyCombat EC;
    private PlayerMovement PM;

    // Start is called before the first frame update
    void Start()
    {
        EC = gameObject.GetComponent<EnemyCombat>();
        PM = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EC.health <= 0)
        {
            PM.HordeDefeated += 1;
        }
    }
}
