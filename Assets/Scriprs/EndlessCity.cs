using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EndlessCity : MonoBehaviour
{
    private Transform carTransform;
    private float halfLength = 80f;

    [SerializeField] Transform otherCity;


    void Start()
    {
        carTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if(carTransform.position.z > transform.position.z+ halfLength+ 10f)
        {
            transform.position =new Vector3(0f,0f,otherCity.position.z + halfLength*2);
        }
    }
}