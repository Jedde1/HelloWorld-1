using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float pointDistance = 1f;
    public Transform path;

    private Transform[] points;
    private int currentPointIndex = 1;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (path == null)
            return;

        points = path.GetComponentsInChildren<Transform>();
    }

    void OnDrawGizmos()
    {
        if (path == null)
            return;

        points = path.GetComponentsInChildren<Transform>();

        Gizmos.color = Color.blue;
        for (int i = 1; i < points.Length -1; i++)
        {
            Vector3 pointA = points[i].position;
            Vector3 pointB = points[i+1].position;
            Gizmos.DrawLine(pointA, pointB);
        }

        Gizmos.color = Color.red;
        for (int i = 1; i < points.Length; i++)
        {
            Vector3 point = points[i].position;
            Gizmos.DrawSphere(point, pointDistance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Transform currentPoint = points[currentPointIndex];

        float distance = Vector3.Distance(transform.position, currentPoint.position);
        if (distance < pointDistance)
        {
            currentPointIndex++;
        }

        if (currentPointIndex >= points.Length)
        {
            currentPointIndex = 1;
        }

        agent.SetDestination(currentPoint.position);
    }
}
