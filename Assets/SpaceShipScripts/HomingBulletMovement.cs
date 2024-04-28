using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 5f;
    public string targetTag = "Enemy"; // Tag to search for target
    private Transform target;

    void Update()
    {
        if (target == null || !target.gameObject.activeSelf)
        {
            FindNearestTarget();
            if (target == null) return; // No target found
        }

        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        if (enemies.Length == 0) return; // No enemies found

        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null)
        {
            target = closestEnemy.transform;
        }
    }
}
