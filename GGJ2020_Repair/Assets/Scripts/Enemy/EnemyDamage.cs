using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damage;
    public float timeBetweenDamage = 1.5f;

    public Platelet currentPlatelet;
    public GameObject player;
    bool _bool;

    float timer;
    public void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenDamage)
        {
            DoDamage();
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
        }
        if (other.collider.gameObject.CompareTag("EnemyTarget"))
        {
            currentPlatelet = other.gameObject.GetComponent<Platelet>();
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            player = null;
        }
        if (other.collider.gameObject.CompareTag("EnemyTarget"))
        {
            currentPlatelet = null;
        }
    }

    public void Die()
    {
        player = null;
        currentPlatelet = null;
    }

    void DoDamage()
    {
        if (player != null)
        {
            PlayerHealth.instance.TakeDamage(damage);
            timer = 0;
        }
        else if (currentPlatelet != null)
        {
            currentPlatelet.TakeDamage(damage);
            timer = 0;
        }

    }
}
