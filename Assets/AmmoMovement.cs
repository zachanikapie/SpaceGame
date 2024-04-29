using UnityEngine;

public class AmmoMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of downward movement
    public float rotationSpeed = 50f; // Speed of rotation

    void Update()
    {
        // Rotate the object around its own pivot point
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Move the object down the Z-axis
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
}
