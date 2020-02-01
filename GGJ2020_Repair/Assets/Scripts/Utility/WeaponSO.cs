using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/new")]
public class WeaponSO : ScriptableObject
{
    public string weaponName;
    [Range(0, 2)] public float fireDelay;
    public GameObject bulletPrefab;
}