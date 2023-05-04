using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Weapons", menuName = "GBJam/New Weapon", order = 0)]
public class Weapons : ScriptableObject 
{
    [SerializeField] 
    private GameObject _weaponPrefab = null;
    [SerializeField]
    private Projectile projectile = null;
    [SerializeField] 
    private int _rateOfFire = 600;
    [SerializeField] 
    private float _damage;
    [SerializeField]
    private float _bulletSpeed = 10;
    [SerializeField]
    private bool _isDamageImpactsOnArea = false;
    [SerializeField]
    private float _damageArea = 1f;
    [SerializeField]
    private bool _isLaunchingSeveralPellets = false;
    [SerializeField]
    private int _pelletsCount = 5;
    [SerializeField]
    private float _spreadAngle;

    [SerializeField] 
    private EffectSoundPlayer _shootSounds;
    [SerializeField]
    private EffectSoundPlayer _impactSounds;
    [SerializeField]
    private GameObject _impactEffect = null;
    [SerializeField] 
    private bool leftHanded;

    const string weaponName = "Weapon";

    public void Equip(Transform rightHand, Transform leftHand) //Animator animator (добавить, когда потребуется анимация)
    {
        DestroyOldWeapon(rightHand, leftHand);
        if (_weaponPrefab != null)
        {
            Transform handTransform = GetTransform(rightHand, leftHand);
            GameObject weapon = Instantiate(_weaponPrefab, handTransform);
            weapon.name = weaponName;
        }
    }

    private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
    {
        Transform oldWeapon = rightHand.Find("Weapon");
        if (oldWeapon == null)
        {
            oldWeapon = leftHand.Find("Weapon");
        }
        if (oldWeapon == null) return;

        oldWeapon.name = "DESTROYING";
        Destroy(oldWeapon.gameObject);
    }

    private Transform GetTransform(Transform rightHand, Transform leftHand)
    {
        Transform handTransform;
        if (leftHanded)
        {
            handTransform = leftHand;
        }
        else
        {
            handTransform = rightHand;
        }

        return handTransform;
    }

    private bool IsWeaponLeftHanded()
    {
        return leftHanded;
    }

    public bool HasProjectile()
    {
        return projectile != null;
    }

    public EffectSoundPlayer GetSoundPlayer()
    {
        return _shootSounds;
    }

    public void LaunchProjectile(Transform rightHand, Transform leftHand, Quaternion rotation, Side side = Side.Default)
    {
        if (_isLaunchingSeveralPellets)
        {
            var spreadAngle = -_spreadAngle / 2;
            var step = (_spreadAngle * 2) / _pelletsCount;   
            for (int i = 0; i < _pelletsCount; i++)
            {
                Transform transform = GetTransform(rightHand, leftHand);
                Vector3 bulletDirection = Quaternion.Euler(0, spreadAngle, 0) * transform.forward;

                Projectile p = Instantiate(projectile, 
                    transform.position, rotation);
                p.transform.forward = bulletDirection;

                InitializeBullet(p, side);
                spreadAngle += step;
            }
        }
        else {
            Projectile projectileInstance = Instantiate(projectile,
            GetTransform(rightHand, leftHand).position, rotation);
            InitializeBullet(projectileInstance, side);
        }
    }

    public float GetDamage()
    {
        return _damage;
    }

    public int GetRateOfFire()
    {
        return _rateOfFire;
    }

    private void InitializeBullet(Projectile projectileInstance, Side side = Side.Default)
    {
        projectileInstance.SetDamage(_damage);
        projectileInstance.SetSpeed(_bulletSpeed);
        projectileInstance.SetImpactEffect(_impactEffect);
        projectileInstance.SetImpactSounds(_impactSounds);
        projectileInstance.SetSide(side);
        if (_isDamageImpactsOnArea)
        {
            projectileInstance.SetAreaDamage(_damageArea);
        }
    }
}