using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAssemble : MonoBehaviour
{
    GameObject carPart;
    [SerializeField] GameObject snapPos;
    [SerializeField] float snapDistance = 5f;
    public static bool canSnap;

    private void Start()
    {
        carPart = gameObject;
    }
    void Update()
    {
        if(Vector3.Distance(carPart.transform.position, snapPos.transform.position) < snapDistance && canSnap)
        {
            carPart.transform.position = snapPos.transform.position;
            carPart.transform.rotation = snapPos.transform.rotation;
        }
    }
}
