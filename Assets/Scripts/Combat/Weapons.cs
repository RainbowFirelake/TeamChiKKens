using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "Zombie Shooter Prototype/Weapons", order = 0)]
public class Weapons : ScriptableObject 
{
    [SerializeField] GameObject weaponPrefab = null;
    [SerializeField] AnimatorOverrideController animatorOverride = null;
    [SerializeField] float attackDistance;
    [SerializeField] private int rateOfFire = 600;
    [SerializeField] private bool isSemiautomatic = false;
    [SerializeField] float damage;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] bool leftHanded;
    [SerializeField] Projectile projectile = null;

    const string weaponName = "Weapon";

    public void Equip(Transform rightHand, Transform leftHand) //Animator animator (добавить, когда потребуется анимация)
    {
        DestroyOldWeapon(rightHand, leftHand);
        if (weaponPrefab != null)
        {
            Transform handTransform = GetTransform(rightHand, leftHand);
            GameObject weapon = Instantiate(weaponPrefab, handTransform);
            weapon.name = weaponName;
        }

        // var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;

        // if (animatorOverride != null)
        // {
        //     animator.runtimeAnimatorController = animatorOverride;
        // }
        // else if (overrideController != null)
        // {
        //     animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;
        // }
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

    public void LaunchProjectile(Transform rightHand, Transform leftHand, GameObject instigator, Quaternion rotation)
    {
        Projectile projectileInstance = Instantiate(projectile,
            GetTransform(rightHand, leftHand).position, rotation);
    }

    public float GetAttackDistance()
    {
        return attackDistance;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetTimeBetweenAttacks()
    {
        return timeBetweenAttacks;
    }

    public int GetRateOfFire()
    {
        return rateOfFire;
    }
}