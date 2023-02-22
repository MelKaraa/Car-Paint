using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour
{
    [SerializeField] GameObject snapPosNormal;
    [SerializeField] GameObject snapPosRight;
    [SerializeField] GameObject snapPosLeft;
    [SerializeField] GameObject snapPosFront;
    [SerializeField] GameObject snapPosRear;
    [SerializeField] float snapDistance = 0.3f;

    void Update()
    {
        Collider[] carParts = Physics.OverlapSphere(transform.position, 5f);
        foreach (Collider carPart in carParts)
        {
            if(carPart.tag == "Car Part Right")
            {
                if (Vector3.Distance(carPart.transform.position, snapPosRight.transform.position) < snapDistance && CarAssemble.canSnap)
                {
                    carPart.transform.position = snapPosRight.transform.position;
                    carPart.transform.rotation = snapPosRight.transform.rotation;
                }
            }
            else if(carPart.tag == "Car Part Left")            
            {
                if (Vector3.Distance(carPart.transform.position, snapPosLeft.transform.position) < snapDistance && CarAssemble.canSnap)
                {
                    carPart.transform.position = snapPosLeft.transform.position;
                    carPart.transform.rotation = snapPosLeft.transform.rotation;
                }
            }
            else if (carPart.tag == "Car Part Front")
            {
                if (Vector3.Distance(carPart.transform.position, snapPosFront.transform.position) < snapDistance && CarAssemble.canSnap)
                {
                    carPart.transform.position = snapPosFront.transform.position;
                    carPart.transform.rotation = snapPosFront.transform.rotation;
                }
            }
            else if (carPart.tag == "Car Part Rear")
            {
                if (Vector3.Distance(carPart.transform.position, snapPosRear.transform.position) < snapDistance && CarAssemble.canSnap)
                {
                    carPart.transform.position = snapPosRear.transform.position;
                    carPart.transform.rotation = snapPosRear.transform.rotation;
                }
            }
            else if (carPart.tag == "Car Part")
            {
                if (Vector3.Distance(carPart.transform.position, snapPosNormal.transform.position) < snapDistance && CarAssemble.canSnap)
                {
                    carPart.transform.position = snapPosNormal.transform.position;
                    carPart.transform.rotation = snapPosNormal.transform.rotation;
                }
            }
        }            
    }
}
