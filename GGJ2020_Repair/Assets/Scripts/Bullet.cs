using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletDamage;
    public float bulletForce = 20f;
    //public GameObject hitEffect;

    Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
    }

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
