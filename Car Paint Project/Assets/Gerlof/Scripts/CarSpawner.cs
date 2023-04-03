using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    public GameObject[] cars;
    public bool trigger;
    public static GameObject currentCar;

    private void Start()
    {
        currentCar = null;
    }
    private void Update()
    {
        if(trigger)
        {
            SpawnCar();
        }
    }
    public void SpawnCar()
    {
        currentCar = Instantiate(cars[Random.Range(0, cars.Length)], spawnPoint.position, spawnPoint.rotation);
        trigger = false;
    }
}
