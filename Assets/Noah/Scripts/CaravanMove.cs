using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanMove : MonoBehaviour
{

    //Reference to waypoints
    public List<Transform> points;
    //The int value for the next point index
    public int nextID = 0;
    //The value of the that applies to ID for changing
    int idChangeValue = 1;
    //Speed of movement or flying
    public float speed = 2;


    public Animator animator;

    //public int maxHealth = 100;
    //public int currentHealth;

    //SpriteRenderer sr;

    private Vector3 targetPos;
    private Vector3 thisPos;
    private float angle;
    public float offset;

    private void Start()
    {
        //sr.GetComponent<SpriteRenderer>();
        //currentHealth = maxHealth;
    }

    private void Reset()
    {
        Init();
    }

    void Init()
    {
        //Make box collider trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root object
        GameObject root = new GameObject(name + "Root");
        //Reset Position of Root to enemy object
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //Create Waypoints object
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints position to enemy to root
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Create two point (gameobject) and reset their position to waypoints objects
        //Make the points children of waypoint object
        GameObject p1 = new GameObject("Point1"); p1.transform.SetParent(waypoints.transform); p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2"); p2.transform.SetParent(waypoints.transform); p2.transform.position = root.transform.position;

        //Init points list then add the points to it
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform goalPoint = points[nextID];

        //Flip the enemy transform to look into the point's direction


        //if (goalPoint.transform.position.y > transform.position.y && goalPoint.transform.position.y != transform.position.y)
        //    transform.rotation = new Quaternion(0, 0, 1, 1);
        //else if (goalPoint.transform.position.y < transform.position.y && goalPoint.transform.position.y != transform.position.y)
        //    transform.rotation = new Quaternion(0, 0, 1, -1);

        //if (goalPoint.transform.position.x > transform.position.x && goalPoint.transform.position.x != transform.position.x)
        //    transform.rotation = new Quaternion(0, 0, 0, 0);
        //else if (goalPoint.transform.position.x < transform.position.x && goalPoint.transform.position.x != transform.position.x)
        //    transform.rotation = new Quaternion(0, 0, -1, 0);

        targetPos = goalPoint.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));


        //Move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed * Time.deltaTime);
        //Check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, goalPoint.position) < 0.2f)
        {
            //Check if we are at the end of the line (make the change -1)
            if (nextID == points.Count - 1)
                idChangeValue = -1;
            //Check if we are at the start of the line (make the change +1)
            if (nextID == 0)
                idChangeValue = 1;
            //Apply the change on the nextID
            nextID += idChangeValue;
        }
    }
}
