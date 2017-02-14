using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float Speed = 15f;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        target = Waypoints.Points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex < Waypoints.Points.Length - 1)
        {
            waypointIndex++;
            target = Waypoints.Points[waypointIndex];
        } else
        {
            Destroy(gameObject);
        }
    }
}
