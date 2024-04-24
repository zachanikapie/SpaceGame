using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    void Update()
    {
        // Move the object down the z-axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
