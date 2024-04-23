using UnityEngine;

public class SpinOnAngle : MonoBehaviour
{
    public Vector3 spinAxis = Vector3.up; // Axis of rotation
    public float spinSpeed = 50f; // Speed of rotation in degrees per second
    public float moveSpeed = 1f;

    void Update()
    {
        // Calculate rotation quaternion
        Quaternion deltaRotation = Quaternion.Euler(spinAxis * spinSpeed * Time.deltaTime);

        // Apply rotation to the object
        transform.rotation *= deltaRotation;

        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
}
