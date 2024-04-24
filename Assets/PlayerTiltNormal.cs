using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float tiltSpeed = 2.0f; // Adjust this value to control the tilt speed
    public float maxTiltAngle = 30.0f; // Maximum tilt angle in degrees
    public float targetYRotation = 180.0f; // Target rotation around the Y axis
    public float targetYPosition = 15.7f; // Target position on the Y axis

    // Update is called once per frame
    void Update()
    {
        // Set the rotation around the Y axis
        transform.rotation = Quaternion.Euler(0, targetYRotation, 0);

        // Get the horizontal input axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the target tilt angle based on input
        float targetTiltAngle = -horizontalInput * maxTiltAngle;

        // Smoothly tilt towards the target tilt angle
        float tiltAngle = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.z, targetTiltAngle, tiltSpeed * Time.deltaTime);

        // Apply the tilt rotation to the spaceship around its forward axis
        transform.rotation = Quaternion.Euler(0, targetYRotation, tiltAngle);

        // Set the position on the Y axis
        transform.position = new Vector3(transform.position.x, targetYPosition, transform.position.z);
    }
}
