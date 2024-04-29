using UnityEngine;

public class OrbitScript : MonoBehaviour
{
    public Transform centerObject; // Reference to the parent object
    public float orbitSpeed = 50f; // Speed of orbiting

    void Update()
    {
        // Make the object orbit around the centerObject
        transform.RotateAround(centerObject.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
