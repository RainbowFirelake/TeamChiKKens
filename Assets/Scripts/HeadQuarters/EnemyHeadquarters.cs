using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHeadquarters : MonoBehaviour
{
    public static event Action OnDestroyEnemyHQ;

    [SerializeField]
    private Health _health;

    void OnEnable()
    {
        _health.OnDie += CheckDie;
    }

    private void CheckDie()
    {
        OnDestroyEnemyHQ?.Invoke();
    }
}
