using UnityEngine;

public class DestructiveRing : MonoBehaviour
{
    public float destructionRadius = 5f; // Adjust this as needed

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "EXP" tag or the "Enemy" tag
        if (other.CompareTag("EXP") || other.CompareTag("Enemy"))
        {
            DestroyObjectsInRange(other);
        }
    }

    private void DestroyObjectsInRange(Collider other)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, destructionRadius);
        foreach (Collider collider in colliders)
        {
            // Check if the collider has the "EXP" tag or the "Enemy" tag before destroying it
            if (collider.CompareTag("EXP") || collider.CompareTag("Enemy"))
            {
                Destroy(collider.gameObject);
            }
        }
    }
}
