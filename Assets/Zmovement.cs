using UnityEngine;

public class ZMovementScript : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of downward movement

    void Update()
    {
        // Move the object down the Z-axis
        transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
    }
}
