using UnityEngine;

public class Rocket : MonoBehaviour
{
    public LivesManager livesManager; // Reference to the LivesManager script
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;

    void Start()
    {
        // Find the LivesManager component in the scene
        livesManager = FindObjectOfType<LivesManager>();
        if (livesManager == null)
        {
            Debug.LogWarning("No LivesManager found in the scene.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FireRocket();
        }
    }

    void FireRocket()
    {
        // Check if the player has rockets available
        if (livesManager != null && livesManager.currentRockets > 0)
        {
            // Instantiate the rocket prefab at the fire point
            var rocket = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            // Set the rocket's velocity
            rocket.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            // Reduce the rocket count
            livesManager.UseRocket();
        }
        else
        {
            Debug.Log("No rockets available!");
        }
    }
}
