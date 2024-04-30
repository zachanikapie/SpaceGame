using UnityEngine;
using System.Collections;

public class MoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 90f; // Degrees per second
    public float rotatePauseDuration = 1f; // Pause duration between rotations
    public float moveDownDuration = 3f; // Time to move down before rotation starts
    public float moveDistance = 5f; // Distance to move down
    
    private bool isRotating = false;
    private bool isMoving = true;

    void Start()
    {
        // Start the movement down
        StartCoroutine(MoveDown());
    }

    IEnumerator MoveDown()
    {
        float startTime = Time.time;
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos - new Vector3(0, 0, moveDistance);

        while (isMoving && Time.time - startTime < moveDownDuration)
        {
            float t = (Time.time - startTime) / moveDownDuration;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        // Stop movement
        isMoving = false;

        // Start rotation
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        while (true)
        {
            // Rotate for a second
            isRotating = true;
            float startRotation = transform.rotation.eulerAngles.y;
            float endRotation = startRotation + 360f;

            float t = 0f;
            float startTime = Time.time;
            while (t < 1f)
            {
                t = (Time.time - startTime) * rotationSpeed / 360f;
                transform.rotation = Quaternion.Euler(0, Mathf.Lerp(startRotation, endRotation, t), 0);
                yield return null;
            }

            // Pause for a second
            yield return new WaitForSeconds(rotatePauseDuration);

            // Reset rotation
            isRotating = false;
        }
    }
}
