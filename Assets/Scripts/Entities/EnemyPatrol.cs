using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<Transform> waypoints;
    public int life;
    public int currentWaypoint;
    int distance;
    float speed;
    float range; 
    Vector3 _dir;
                           
    void Start ()
    {              
        speed = 1;        

        transform.position = waypoints[currentWaypoint].position;
        _dir = waypoints[currentWaypoint + 1].position - waypoints[currentWaypoint].position;
    }

    void Update()
    {       
        float distance = Vector3.Distance(transform.position, waypoints[currentWaypoint + 1].position);

        if (distance > range)
            transform.position += _dir * speed * Time.deltaTime;
        else
            CalculateDirection();
    }

    void CalculateDirection()
    {
        if (currentWaypoint + 1 < waypoints.Count - 1)
        {
            currentWaypoint++;
            _dir = waypoints[currentWaypoint + 1].position - waypoints[currentWaypoint].position;
        }
    }    

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        if (collision.gameObject.layer == 9)
            Destroy(this.gameObject);
    }
}
