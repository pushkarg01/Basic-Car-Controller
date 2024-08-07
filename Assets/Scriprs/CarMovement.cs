using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] WheelCollider frontRightWheelCollider;
    [SerializeField] WheelCollider frontLeftWheelCollider;
    [SerializeField] WheelCollider backRightWheelCollider;
    [SerializeField] WheelCollider backLeftWheelCollider;


    [SerializeField] Transform frontRightWheelTransform;
    [SerializeField] Transform frontLeftWheelTransform;
    [SerializeField] Transform backRightWheelTransform;
    [SerializeField] Transform backLeftWheelTransform;

    [SerializeField] Transform carCenterOfMass;

    [SerializeField] float motorForce = 100f;
    [SerializeField] float steerRotation = 50f;
    [SerializeField] float brakeForce = 1000f;

    private Rigidbody rb;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.centerOfMass=carCenterOfMass.localPosition;
    }

   
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
        InputMovement();
        Steering();
        ApplyBreak();
    }

    void InputMovement()
    {
        horizontalInput =Input.GetAxis("Horizontal");
        verticalInput =Input.GetAxis("Vertical");
    }

    void ApplyBreak()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontRightWheelCollider.brakeTorque = brakeForce;
            frontLeftWheelCollider.brakeTorque = brakeForce;
            backRightWheelCollider.brakeTorque = brakeForce;
            backLeftWheelCollider.brakeTorque = brakeForce;
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0f;
            frontLeftWheelCollider.brakeTorque = 0f;
            backRightWheelCollider.brakeTorque = 0f;
            backLeftWheelCollider.brakeTorque = 0f;
        }
        
    }

   void MotorForce()
    {    
            frontRightWheelCollider.motorTorque = motorForce * verticalInput;
            frontLeftWheelCollider.motorTorque = motorForce * verticalInput;

    }

    void Steering()
    {
        frontRightWheelCollider.steerAngle = steerRotation * horizontalInput;
        frontLeftWheelCollider.steerAngle = steerRotation * horizontalInput;
    }

    void UpdateWheels()
    {
        RotateWheel(frontRightWheelCollider,frontRightWheelTransform);
        RotateWheel(frontLeftWheelCollider,frontLeftWheelTransform);
        RotateWheel(backRightWheelCollider,backRightWheelTransform);
        RotateWheel(backLeftWheelCollider,backLeftWheelTransform);
    }

    void RotateWheel(WheelCollider wheelCollider , Transform transform)
    {
        Vector3 pos;
        Quaternion quat;
        wheelCollider.GetWorldPose(out pos, out quat);
        transform.position = pos;   
        transform.rotation = quat;
    }
}
