using UnityEngine;

public class EnemyTilt : MonoBehaviour
{
    public float tiltAngle = 30f; // Maximum tilt angle
    public float tiltSpeed = 5f; // Tilt speed
    public float initialYPosition; // Initial y-position

    void Start()
    {
        // Store the initial y-position
        initialYPosition = transform.position.y;
    }

    void Update()
    {
        // Detect movement on the X-axis
        float movementX = Input.GetAxis("Horizontal");

        // Calculate the tilt amount based on the movement on the X-axis
        float tiltAmount = movementX * tiltAngle;

        // Calculate the current rotation
        Quaternion currentRotation = transform.rotation;

        // Set the desired X rotation to -90 degrees
        Quaternion xRotation = Quaternion.Euler(-90f, 0f, 0f);

        // Calculate the new rotation based on the tilt amount around the Y-axis
        Quaternion yRotation = Quaternion.Euler(0f, tiltAmount, 0f);

        // Combine the X and Y rotations
        Quaternion targetRotation = xRotation * yRotation;

        // Set the Z rotation to 180 degrees
        targetRotation *= Quaternion.Euler(0f, 0f, -90f);

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, tiltSpeed * Time.deltaTime);

        // Keep the object at the same y-position
        transform.position = new Vector3(transform.position.x, initialYPosition, transform.position.z);
    }
}
