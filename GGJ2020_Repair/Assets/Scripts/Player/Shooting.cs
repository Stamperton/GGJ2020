using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;

    public WeaponSO defaultWeapon;
    public WeaponSO currentWeapon;

    float fireTimer;

    //Components
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
            fireTimer = 0f;
            audioSource.Play();
        }
    }
}
