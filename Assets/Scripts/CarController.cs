
// using UnityEngine;

// public class CarController : MonoBehaviour
// {
//     public float moveSpeed = 10f;   // Speed of the car movement
//     public float rotationSpeed = 100f;  // Speed of the car rotation
//     public RoadManager roadManager; // Reference to the RoadManager script

//     void Update()
//     {
//         // Rotation based on user input
//         float horizontalInput = Input.GetAxis("Horizontal");
//         transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

//         // Move forward if player presses the up arrow or W key
//         float verticalInput = Input.GetAxis("Vertical");
//         if (verticalInput > 0)
//         {
//             transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

//         }
//     }
// }

// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CarController : MonoBehaviour
// {
//     private float horizontalInput, verticalInput;
//     private float currentSteerAngle, currentbreakForce;
//     private bool isBreaking;

//     // Settings
//     [SerializeField] private float motorForce, breakForce, maxSteerAngle;

//     // Wheel Colliders
//     [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
//     [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

//     // Wheels
//     [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
//     [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

//     private void FixedUpdate() {
//         GetInput();
//         HandleMotor();
//         HandleSteering();
//         UpdateWheels();
//     }

//     private void GetInput() {
//         // Steering Input
//         horizontalInput = Input.GetAxis("Horizontal");

//         // Acceleration Input
//         verticalInput = Input.GetAxis("Vertical");

//         // Breaking Input
//         isBreaking = Input.GetKey(KeyCode.Space);
//     }

//     private void HandleMotor() {
//         frontLeftWheelCollider.motorTorque = Mathf.Max(verticalInput, 0f) * motorForce;
//         frontRightWheelCollider.motorTorque = Mathf.Max(verticalInput, 0f) * motorForce;
//         currentbreakForce = isBreaking ? breakForce : 0f;
//         ApplyBreaking();
//     }

//     private void ApplyBreaking() {
//         frontRightWheelCollider.brakeTorque = currentbreakForce;
//         frontLeftWheelCollider.brakeTorque = currentbreakForce;
//         rearLeftWheelCollider.brakeTorque = currentbreakForce;
//         rearRightWheelCollider.brakeTorque = currentbreakForce;
//     }

//     private void HandleSteering() {
//         currentSteerAngle = maxSteerAngle * horizontalInput;
//         frontLeftWheelCollider.steerAngle = currentSteerAngle;
//         frontRightWheelCollider.steerAngle = currentSteerAngle;
//     }

//     private void UpdateWheels() {
//         UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
//         UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
//         UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
//         UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
//     }

//     private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
//         Vector3 pos;
//         Quaternion rot; 
//         wheelCollider.GetWorldPose(out pos, out rot);
//         wheelTransform.rotation = rot;
//         wheelTransform.position = pos;
//     }
// }


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle=70;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;

    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput() {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor() {
        frontLeftWheelCollider.motorTorque = Mathf.Max(verticalInput, 0f) * motorForce;
        frontRightWheelCollider.motorTorque = Mathf.Max(verticalInput, 0f) * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Obstacle"))
        {
            motorForce -= motorForce/2;
            Debug.Log("Obstacle hit" + motorForce);
        }
        if (other.CompareTag("Fuel"))
        {
            motorForce += motorForce+250;
            Debug.Log("Obstacle hit" + motorForce);
        }
    }
    

    private void ApplyBreaking() {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering() {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}