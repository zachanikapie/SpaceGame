using System.Collections;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireInterval = 0.5f; // Time interval between each shot

    private bool canShoot = true;

    void Start()
    {
        // Start the shooting coroutine with a delay
        StartCoroutine(StartShootingWithDelay(1f));
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
