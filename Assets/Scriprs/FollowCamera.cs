using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform carTransform;
    private Transform cameraPointTransform;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        carTransform =GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraPointTransform = carTransform.Find("CameraPoint").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.LookAt(carTransform.position);
        transform.position = Vector3.SmoothDamp(transform.position,cameraPointTransform.position,ref velocity,7f*Time.deltaTime);
    }
}
