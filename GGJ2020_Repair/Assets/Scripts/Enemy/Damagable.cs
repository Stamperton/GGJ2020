using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public float health;
    public Sprite deadSprite;

    bool isDead;


    //Variables
    Animator anim;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        SpawnManager.instance.currentEnemies++;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        PlayerHealth.instance.kills++;
        PlayerHealth.instance.UpdateUI();
        SpawnManager.instance.currentEnemies--;
        anim.SetBool("Dead", true);
        GetComponent<EnemyMovement>().Die();
        GetComponent<EnemyDamage>().Die();
        spriteRenderer.sprite = deadSprite;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().Sleep();
        Destroy(gameObject, 10f);
    }
}
