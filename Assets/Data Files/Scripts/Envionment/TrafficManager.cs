using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] Transform[] lanesTransform;
    [SerializeField] GameObject[] obstacleVehicles;

    private CarMovement carMovement;

    private float dynamicTime = 2f;

    private void Awake()
    {
        carMovement = GameObject.FindWithTag("Player").GetComponent<CarMovement>();
    }
    private void Start()
    {
        StartCoroutine(TrafficSpawner());
    }
    IEnumerator TrafficSpawner()
    {
        yield return new WaitForSeconds(2f);

        while (true)
        {  
            if (carMovement.CarSpeed() > 20f)
            {
                dynamicTime = Random.Range(30f, 50f) / carMovement.CarSpeed();
                SpawnTrafficVehicles();
            }
            yield return new WaitForSeconds(dynamicTime);
        }
    }

    private void SpawnTrafficVehicles()
    {
        Instantiate(obstacleVehicles[Random.Range(0, obstacleVehicles.Length)],
                    lanesTransform[Random.Range(0, lanesTransform.Length)].position, Quaternion.identity,transform);
    }
}
