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
        float x = currentWeapon.GetRateOfFire() / 60;
        timeOnOneShot = 1 / x;
        if (timeAfterLastShoot > timeOnOneShot)
        {
            currentWeapon.LaunchProjectile(rightHandTransform, leftHandTransform, this.gameObject, transform.rotation);
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
        currentWeapon.Equip(rightHandTransform, leftHandTransform);
    }

    private Weapons SetupDefaultWeapon()
    {
        AttachWeapon(defaultWeapon);
        return defaultWeapon;
    }
}
