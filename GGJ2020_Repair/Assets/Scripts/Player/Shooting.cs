using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public WeaponSO defaultWeapon;
    public WeaponSO currentWeapon;

    float fireTimer;

    //Components
    AudioSource audioSource;

    void Start()
    {
        currentWeapon = defaultWeapon;
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;

        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (fireTimer >= currentWeapon.fireDelay)
        {
            GameObject _bullet = Instantiate(currentWeapon.bulletPrefab, firepoint.position, firepoint.rotation);
            _bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            fireTimer = 0f;
        }
    }
}
