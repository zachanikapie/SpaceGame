using System.Collections;
using UnityEngine;

public class EnemyBossGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireInterval = 0.5f; // Time interval between each shot
    public float initialDelay = 1f; // Initial delay before the enemy starts shooting

    private bool canShoot = true;

    public void Start()
    {
        // Start the shooting coroutine with a delay
        StartCoroutine(StartShootingWithDelay(initialDelay));
    }

    IEnumerator StartShootingWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            if (canShoot)
            {
                Shoot();
                canShoot = false;
                yield return new WaitForSeconds(fireInterval);
                canShoot = true;
            }
            yield return null;
        }
    }

    void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
