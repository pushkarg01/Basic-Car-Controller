using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    private Transform carTransform;
    [SerializeField] float offset = 20f;

    void Start()
    {
        carTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = carTransform.position.z + offset;
        transform.position = cameraPos;
    }
}
