using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    #region Variables

    [SerializeField] WheelCollider frontRightWheelCollider, frontLeftWheelCollider, backRightWheelCollider, backLeftWheelCollider;

    [SerializeField] Transform frontRightWheelTransform, frontLeftWheelTransform, backRightWheelTransform, backLeftWheelTransform;

    [SerializeField] Transform carCenterOfMass;

    [SerializeField] float motorForce = 100f, brakeForce = 1000f;
    [SerializeField] float steerRotation = 30f;

    private Rigidbody rb;
    private float horizontalInput, verticalInput;
    #endregion

    #region Start Logic
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        rb.centerOfMass=carCenterOfMass.localPosition;
    }
    #endregion

    #region FixedUpdate Logic

    void FixedUpdate()
    {
        GetInputMovement();
        MotorForce();
        Steering();
        UpdateWheels();
        ApplyBreak();
    }
    #endregion

    #region Movement and Steering Logic
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
    #endregion

    #region Wheel Rotation Logic
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
    #endregion

    #region Break Logic
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
    #endregion

}
