using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    //public GameObject hitEffect;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Damagable _damagable = collision.gameObject.GetComponent<Damagable>();
        if (_damagable)
        {
            _damagable.TakeDamage(bulletDamage);
        }

        //GameObject hitEffect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(hitEffect, 5f);
        Destroy(gameObject);
    }
    
}
