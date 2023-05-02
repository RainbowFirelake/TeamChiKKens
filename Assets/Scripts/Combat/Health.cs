using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float healthPoints = 100f;
    [SerializeField] private float maxHealthPoints = 100f;

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

        isDead = true;
        Destroy(this.gameObject);
    }
}
