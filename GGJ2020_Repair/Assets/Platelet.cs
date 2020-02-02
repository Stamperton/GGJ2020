using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platelet : MonoBehaviour
{
    Rigidbody2D rb2D;

    public Sprite deadSprite;

    public float health;
    public float timeBetweenHeals;
    public float healAmount;
    public float moveSpeed = 1.5f;
    float timer;
    bool isDead;
    Transform targetPosition;

    Wound currentWound;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        timer += Time.deltaTime;

        Move();

        if (currentWound)
        {
            Debug.Log("WoundFound");
            if (timer >= timeBetweenHeals)
            {
                timer = 0f;
                currentWound.Heal(healAmount);

                if (currentWound == null || currentWound.isHealed)
                {
                    targetPosition = null;
                    GetNewTarget();
                }
            }
        }

        else
        {
            GetNewTarget();
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wound"))
        {
            currentWound = other.GetComponent<Wound>();
        }
        if (other.CompareTag("Healed"))
        {

            GetNewTarget();
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Wound"))
        {
            currentWound = null;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Move()
    {
        if (!isDead)
        {
            TrackTarget(targetPosition);

            if (targetPosition == null)
            {
                GetNewTarget();
            }

        }
    }

    void TrackTarget(Transform target)
    {
        if (target != null)
        {

            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            Vector2 lookDir = new Vector2(target.position.x, target.position.y) - rb2D.position;

            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb2D.rotation = angle;
        }
    }

    void GetNewTarget()
    {
        if (targetPosition != null)
            return;
        
            Transform newTarget = SpawnManager.instance.FindWoundDestination();

        currentWound = null;
        targetPosition = null;

        if (newTarget != null)
        {
            targetPosition = newTarget.transform;
        }
        else
            return;

    }

    void Die()
    {
        isDead = true;
        GetComponent<Animator>().SetBool("Dead", true);
        GetComponent<SpriteRenderer>().sprite = deadSprite;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 9f);
    }
}
