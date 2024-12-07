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

    [SerializeField] float motorForce = 100f, brakeForce = 1000f;
    [SerializeField] float steerRotation = 30f;

    private Rigidbody rb;
    private float horizontalInput, verticalInput;

    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.centerOfMass=carCenterOfMass.localPosition;
    }
   
    void FixedUpdate()
    {
        GetInputMovement();
        MotorForce();
        Steering();
        UpdateWheels();
        PowerSteering();
        ApplyBreak();
    }

    void GetInputMovement()
    {
        horizontalInput =Input.GetAxis("Horizontal");
        verticalInput =Input.GetAxis("Vertical");
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

    void PowerSteering()
    {
        if (horizontalInput == 0)
        {
            transform.rotation= Quaternion.Slerp(transform.rotation,Quaternion.Euler(0f,0f,0f),Time.deltaTime);
        }
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

    void ApplyBreak()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontRightWheelCollider.brakeTorque = brakeForce;
            frontLeftWheelCollider.brakeTorque = brakeForce;
            backRightWheelCollider.brakeTorque = brakeForce;
            backLeftWheelCollider.brakeTorque = brakeForce;

            rb.drag = 1f;
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0f;
            frontLeftWheelCollider.brakeTorque = 0f;
            backRightWheelCollider.brakeTorque = 0f;
            backLeftWheelCollider.brakeTorque = 0f;

            rb.drag = 0f;
        }
    }

    public float CarSpeed()
    {
        float speed=rb.velocity.magnitude * 2.23693629f;
        return speed;
    }

}
