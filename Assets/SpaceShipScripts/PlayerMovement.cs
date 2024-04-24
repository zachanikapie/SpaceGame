using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 7f; // Speed of forward movement
    public float backwardSpeed = 3f; // Speed of backward movement
    public float sidewaysSpeed = 5f; // Speed of sideways movement
    public float tiltAngle = 30f; // Maximum tilt angle
    public Animator animator; // Reference to the Animator component
    public float minX = -26f; // Minimum X position boundary
    public float maxX = 25f; // Maximum X position boundary
    public float minZ = -38f; // Minimum Z position boundary
    public float maxZ = 36f; // Maximum Z position boundary

    void Update()
    {
        // Get input from the user
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Determine the speed based on the input direction
        float currentSpeed = forwardInput > 0 ? forwardSpeed : forwardInput < 0 ? backwardSpeed : 0;

        // Calculate the movement direction
        Vector3 movement = transform.forward * forwardInput * currentSpeed + transform.right * horizontalInput * sidewaysSpeed;
        movement *= Time.deltaTime;

        // Apply movement to the object
        transform.Translate(movement);

        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);
        transform.position = clampedPosition;
    }
}
