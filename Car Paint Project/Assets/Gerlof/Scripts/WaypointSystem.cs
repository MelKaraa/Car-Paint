using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class WaypointSystem : MonoBehaviour
{
    private Transform target;
    [SerializeField] private int waypointindex = 0;

    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator door1;
    [SerializeField] private Animator door2;
    [SerializeField] bool end;
    [SerializeField] bool shopEntered;

    void Start()
    {
        target = Waypoints.points[0];
        end = false;
    }

    void Update()
    {   
        if(!end)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);
        }
        
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            if(waypointindex == 0)
            {
                door1.SetTrigger("DoorMove");
            }
            else if (waypointindex == 3 && !shopEntered)
            {
                InShop();
            }
            else if(waypointindex == 4 && shopEntered)
            {
                door2.SetTrigger("DoorMove");
            }

            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {
        if (waypointindex >= Waypoints.points.Length - 1)
        {
            ExitShop();
            end = true;
        }
        if (end)
            return;
        waypointindex++;
   
        target = Waypoints.points[waypointindex];

        transform.LookAt(target);
    }

    void InShop()
    {
        if(!shopEntered) 
        {
            door1.SetTrigger("DoorMove");
            Debug.Log("Car has arrived");
            shopEntered = true;
            end = true;
        }
        
    }

    void ExitShop()
    {
        if(!end)
        door2.SetTrigger("DoorMove");
    }

}
