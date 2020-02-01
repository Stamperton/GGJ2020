using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    void Awake()
    {
        instance = this;
    }

    public float health;
    public Text healthText;
    public float kills;
    public Text killsText;
    void Start()
    {
        UpdateUI();
    }


    public void TakeDamage(float damage)
    {
        health = Mathf.Clamp(health - damage, 0, 100);
        healthText.text = health.ToString();
        if (health <= 0)
            Die();
    }

    public void UpdateUI()
    {
        healthText.text = health.ToString();
        killsText.text = kills.ToString();
    }

    void Die()
    {

    }
}
