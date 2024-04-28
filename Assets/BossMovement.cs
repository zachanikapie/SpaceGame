using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 1.0f; // Speed of movement
    public float endZPosition = 35.0f; // Target Z position

    private void Update()
    {
        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, endZPosition), speed * Time.deltaTime);
        
        // Check if the object has reached the target position
        if (transform.position.z == endZPosition)
        {
            // Do something when the object reaches the target position, if needed
            Debug.Log("Object reached the target position!");
        }
    }
}
