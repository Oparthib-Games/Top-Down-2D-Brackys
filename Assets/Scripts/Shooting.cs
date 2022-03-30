using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject muzzleFlash;

    public float bulletForce = 2f;
    public float shootRate = 0.5f;
    private float shootTimer = 0f;

    bool doShoot = false;

    public void FixedUpdate()
    {
        if (!doShoot) return;

        if (Time.time > shootTimer){

            GameObject bullet_GO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            GameObject muzzleFlash_GO = Instantiate(muzzleFlash, firePoint.position, Random.rotation);

            Rigidbody2D RB2D = bullet_GO.GetComponent<Rigidbody2D>();
            RB2D.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            Destroy(muzzleFlash_GO, 3f);
            Destroy(bullet_GO, 3f);

            shootTimer += shootRate;
        }
    }
    public void ShootStart()
    {
        doShoot = true;
    }

    public void ShootStop()
    {
        doShoot = false;
    }
}
