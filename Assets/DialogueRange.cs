using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DialogueRange : MonoBehaviour
{
    public float dialogueRange = 3f;
    private Transform player;
    public Dialogue dialogue;

    private AIPath path;
    private npcMovement mov;
    private npcShoot shoot;
    private Version2AIDestinationSetter v2;

    // Start is called before the first frame update
    void Start()
    {
        dialogue.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;

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
        Vector3 targ = player.position;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float distanceFromTarget = Vector2.Distance(player.position, transform.position);
        if (distanceFromTarget < dialogueRange)
        {
            dialogue.enabled = true;
        }

        if (dialogue.dialogueFinished == true)
        {
            path.enabled = true;
            mov.enabled = true;
            shoot.enabled = true;
            v2.enabled = true;
        }

        //if (dialogue.dialogueFinished == false)
        //{
        //    path.enabled = false;
        //    mov.enabled = false;
        //    shoot.enabled = false;
        //    v2.enabled = false;
        //}

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, dialogueRange);
    }
}
