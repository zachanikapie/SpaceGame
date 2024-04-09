using UnityEngine;

public class GimbalRotation : MonoBehaviour
{
    public float rotationSpeedX = 50f; // Rotation speed around local X-axis
    public float rotationSpeedY = 30f; // Rotation speed around local Y-axis

    void Update()
    {
        // Rotate the parent object
        transform.Rotate(Vector3.up, rotationSpeedY * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeedX * Time.deltaTime);
    }
}
