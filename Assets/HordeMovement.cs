using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HordeMovement : MonoBehaviour
{
    //public AIPath aIPath;

    public AIDestinationSetter Destination;
    public EnemyMovement Move;
    public AIPath Path;

    public GateV2 gate;

    // Start is called before the first frame update
    void Start()
    {
        Destination = gameObject.GetComponent<AIDestinationSetter>();
        Move = gameObject.GetComponent<EnemyMovement>();
        Path = gameObject.GetComponent<AIPath>();

        Destination.enabled = false;
        Move.enabled = false;
        Path.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gate.PlayerInCamp == true)
        {
            Destination.enabled = true;
            Move.enabled = true;
            Path.enabled = true;
        }
    }
}