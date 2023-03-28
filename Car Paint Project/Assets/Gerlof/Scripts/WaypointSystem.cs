using UnityEngine;
using System.Collections;

public class WaypointSystem : MonoBehaviour
{
    private Transform target;
    private int waypointindex = 0;

    [SerializeField] private float movementSpeed;
   

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {      
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        transform.LookAt(target);
    }

    void GetNextWaypoint()
    {
        if (waypointindex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        waypointindex++;
        target = Waypoints.points[waypointindex];
    }

    void EndPath()
    {
        Debug.Log("Car has arrived");
    }

}
