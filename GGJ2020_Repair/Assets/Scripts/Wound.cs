using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour
{
    public float woundHealth;
    public float woundMaxHealth;
    public bool isHealed;

    public Sprite halfHealed;
    public Sprite healed;

    GameObject weaponPickup;
    SpriteRenderer spriteRenderer;

    public CircleCollider2D[] notHealedColliders;
    public CircleCollider2D[] halfHealedColliders;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SpawnManager.instance.AddToList(this);
        weaponPickup = transform.GetChild(0).gameObject;
    }

    public void Heal(float heal)
    {
        woundHealth = Mathf.Clamp(woundHealth += heal, 0, woundMaxHealth);
        if (woundHealth >= (woundMaxHealth / 2) && spriteRenderer.sprite != halfHealed)
        {
            spriteRenderer.sprite = halfHealed;

            for (int i = 0; i < notHealedColliders.Length; i++)
            {
                notHealedColliders[i].enabled = false;
            }
            for (int i = 0; i < halfHealedColliders.Length; i++)
            {
                halfHealedColliders[i].enabled = true;
            }

        }

        if (woundHealth >= woundMaxHealth)
        {
            isHealed = true;
            gameObject.tag = "Healed";
            spriteRenderer.sprite = healed;
            SpawnManager.instance.RemoveFromList(this);

            weaponPickup.SetActive(true);

            for (int i = 0; i < halfHealedColliders.Length; i++)
            {
                halfHealedColliders[i].enabled = false;
            }
        }
    }


}
