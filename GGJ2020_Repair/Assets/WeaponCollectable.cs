using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectable : MonoBehaviour
{
    public WeaponSO[] weaponToPickup;
    public WeaponSO weaponToSpawn;

    private void Start()
    {
        weaponToSpawn = weaponToPickup[Random.Range(0, weaponToPickup.Length)];
        GetComponent<SpriteRenderer>().sprite = weaponToSpawn.weaponImage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Shooting>().currentWeapon = weaponToSpawn;

            GetComponent<AudioSource>().Play();

            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
