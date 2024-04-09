using UnityEngine;

public class SpaceshipRotate : MonoBehaviour
{
    public float rotateSpeed = 100f; // Rotation speed

    void Update()
    {
        // Get input from the user
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the rotation amount based on the input
        float rotationAmount = horizontalInput * rotateSpeed * Time.deltaTime;

        // Apply rotation around the local up (y) axis
        transform.Rotate(transform.up, rotationAmount, Space.Self);
    }
}
