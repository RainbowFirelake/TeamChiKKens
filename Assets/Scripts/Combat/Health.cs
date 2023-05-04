using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static event Action<Side> OnDie;

    [SerializeField] private float healthPoints = 100f;
    [SerializeField] private float maxHealthPoints = 100f;
    [SerializeField] private SideManager _sideManager;

    private bool isDead = false;

    public float GetHealth()
    {
        return healthPoints;
    }

    public float GetMaxHealth()
    {
        return maxHealthPoints;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public Side GetSide()
    {
        return _sideManager.GetSide();
    }

    public void TakeDamage(float damage)
    {
        healthPoints = Mathf.Max(healthPoints - damage, 0);
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        OnDie?.Invoke(GetSide());
        isDead = true;
        Destroy(this.gameObject);
    }
}
