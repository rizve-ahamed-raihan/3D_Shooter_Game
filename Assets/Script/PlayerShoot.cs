
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.3f;

    private float nextFireTime;
    private Collider playerCol;

    void Awake()
    {
        playerCol = GetComponent<Collider>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogError("Bullet Prefab or FirePoint NOT assigned!");
            return;
        }

        GameObject bullet = Instantiate(
            bulletPrefab,
            firePoint.position,
            firePoint.rotation   // ✅ THIS IS CRITICAL
        );

        // Ignore player collision
        Collider bulletCol = bullet.GetComponent<Collider>();
        if (bulletCol != null && playerCol != null)
        {
            Physics.IgnoreCollision(bulletCol, playerCol);
        }

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Fire(firePoint.forward);
        }
        else
        {
            Debug.LogError("Bullet prefab is missing Bullet.cs!");
        }
    }
}
