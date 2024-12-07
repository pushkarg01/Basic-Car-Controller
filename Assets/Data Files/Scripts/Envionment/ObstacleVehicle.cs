using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVehicle : MonoBehaviour
{
    [SerializeField] float zSpeed = 5f;
    private void Update()
    {
        transform.Translate(0f, 0f, zSpeed*Time.deltaTime);
    }
}
