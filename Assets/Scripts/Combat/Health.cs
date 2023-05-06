using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static event Action OnChangeMan;
    public static event Action<Side> OnEnemyDie;
    public event Action OnDie;

    public event Action<float> OnUpdateHealth;

    [SerializeField] private float healthPoints = 100f;
    [SerializeField] private float maxHealthPoints = 100f;
    [SerializeField] private SideManager _sideManager;
    [SerializeField] private bool _destroyOnDie = true;
    [SerializeField] private bool _isPlayer = false;

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
        OnUpdateHealth?.Invoke(healthPoints);
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        if (_isPlayer)
        {
            OnChangeMan?.Invoke();
            return;
        }
        OnEnemyDie?.Invoke(GetSide());
        OnDie?.Invoke();
        isDead = true;
        if (_destroyOnDie)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(float value)
    {
        healthPoints = value;
        OnUpdateHealth?.Invoke(healthPoints);
    }
}
