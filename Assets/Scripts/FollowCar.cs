using UnityEngine;

public class FollowCar : MonoBehaviour
{
    public Transform target; // Reference to the car's transform
    public float smoothness = 5f; // Smoothing factor for camera movement

    private Vector3 offset; // Offset between the camera and the car

    void Start()
    {
        // Calculate the initial offset between the camera and the car
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        // Calculate the target position for the camera
        Vector3 targetPosition = target.position + offset;

        // Move the camera towards the target position with smoothing
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness * Time.deltaTime);
    }
}
