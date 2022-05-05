using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CampNPC : MonoBehaviour
{
    //public AIPath caravan;
    public GateV2 gate;

    private AIPath path;
    private npcMovement mov;
    private npcShoot shoot;
    private Version2AIDestinationSetter v2;

    // Start is called before the first frame update
    void Start()
    {
        path = gameObject.GetComponent<AIPath>();
        mov = gameObject.GetComponent<npcMovement>();
        shoot = gameObject.GetComponent<npcShoot>();
        v2 = gameObject.GetComponent<Version2AIDestinationSetter>();

        path.enabled = false;
        mov.enabled = false;
        shoot.enabled = false;
        v2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gate.PlayerInCamp == true)
        {
                path.enabled = true;
                mov.enabled = true;
                shoot.enabled = true;
                v2.enabled = true;
        }

        //if (caravan.reachedEndOfPath == true)
        //{
        //    path.enabled = true;
        //    mov.enabled = true;
        //    shoot.enabled = true;
        //    v2.enabled = true;
        //}
    }
}
