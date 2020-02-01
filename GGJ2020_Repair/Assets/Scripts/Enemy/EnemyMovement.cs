using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Variables
    public Transform player;
    public Transform targetPosition;

    bool isDead = false;
    bool trackingPlayer = true;
    public float movespeed;

    //Components
    Rigidbody2D rb2D;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        GetNewTarget();
    }

   
 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyTarget"))
        {
            trackingPlayer = false;
            targetPosition = other.transform;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isDead)
        {
            if (trackingPlayer)
            {
                TrackTarget(player);
            }
            else if (targetPosition == null)
            {
                GetNewTarget();
            }
            else
            {
                TrackTarget(targetPosition);
            }


        }
    }

    void TrackTarget(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);

        Vector2 lookDir = new Vector2(target.position.x, target.position.y) - rb2D.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2D.rotation = angle;
    }

    public void Die()
    {
        isDead = true;
    }

    void GetNewTarget()
    {
        GameObject newTarget = GameObject.FindGameObjectWithTag("EnemyTarget");
        targetPosition = newTarget.transform;

        if (targetPosition == null)
        {
            trackingPlayer = true;
        }
    }
}
