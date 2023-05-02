using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Weapons currentWeapon = null;
    [SerializeField] private Weapons defaultWeapon = null;
    [SerializeField] Transform rightHandTransform = null;
    [SerializeField] Transform leftHandTransform = null;

    private float timeAfterLastShoot = Mathf.Infinity;
    private float timeOnOneShot;

    private void Start() 
    {
        SetupDefaultWeapon();
    }

    private void Update() 
    {
        timeAfterLastShoot += Time.deltaTime;
    }

    public void Shoot()
    {
        if (timeAfterLastShoot > timeOnOneShot)
        {
            currentWeapon.LaunchProjectile(rightHandTransform, leftHandTransform, transform.rotation);
            timeAfterLastShoot = 0;
        }
    }

    public void EquipWeapon(Weapons weapon)
    {
        currentWeapon = weapon;
        AttachWeapon(weapon);
    }

    private void AttachWeapon(Weapons weapon)
    {
        InitializeRateOfFire();
        currentWeapon.Equip(rightHandTransform, leftHandTransform);
    }

    private Weapons SetupDefaultWeapon()
    {
        AttachWeapon(defaultWeapon);
        return defaultWeapon;
    }

    private void InitializeRateOfFire()
    {
        float x = (float)currentWeapon.GetRateOfFire() / 60;
        timeOnOneShot = 1 / x;
        timeAfterLastShoot = Mathf.Infinity;
    }
}
