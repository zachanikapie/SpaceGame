using UnityEngine;

public class ZigZagsMove : MonoBehaviour
{
    public float speed = 2;
    public float frequency = 10.0f; // Speed of sine movement
    public float magnitude = 0.5f; // Size of sine movement
    public float maxMovement = 10.0f; // Maximum movement along the x-axis

    private Vector3 startPos;
    private Vector3 axis;
    private bool rotating = false;

    private void Awake()
    {
        startPos = transform.position;
        axis = Vector3.right; // Move along the x-axis
    }

    void Update()
    {
        // Calculate the new position
        float moveAmount = Time.deltaTime * speed;
        startPos += Vector3.back * moveAmount;
        transform.position = startPos + axis * Mathf.Sin(Time.time * frequency) * magnitude;

        // Check if reached the maximum magnitude to rotate
        if (transform.position.x >= startPos.x + maxMovement || transform.position.x <= startPos.x - maxMovement)
        {
            rotating = true;
        }

        if (rotating)
        {
            // Rotate along the z-axis
            float rotationAmount = Time.deltaTime * speed * (transform.position.x >= startPos.x + maxMovement ? -1 : 1);
            transform.Rotate(Vector3.forward, rotationAmount);

            // Lock x rotation at -90 degrees
            transform.rotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            // Stop rotating when the rotation reaches 0
            if (Mathf.Abs(transform.rotation.eulerAngles.z) < 1)
            {
                rotating = false;
            }
        }
    }
}
