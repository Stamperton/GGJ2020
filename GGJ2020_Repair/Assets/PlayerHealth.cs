using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    #region Singleton
    public static PlayerHealth instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    GameObject player;

    public Sprite deadPlayerSprite;

    public float health;
    public Text healthText;
    public float kills;
    public Text killsText;
    public Text killsText2;

    public Canvas gameCanvas;
    public Canvas gameOverCanvas;

    void Start()
    {
        gameCanvas.gameObject.SetActive(true);
        gameOverCanvas.gameObject.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
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
        killsText2.text = kills.ToString();
    }

    void Die()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<SpriteRenderer>().sprite = deadPlayerSprite;
        player.GetComponent<Shooting>().enabled = false;
        gameOverCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
