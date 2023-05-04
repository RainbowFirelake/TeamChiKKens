using UnityEngine;
using System;

public class PlayerHeadQuarters : MonoBehaviour
{
    public static event Action OnDestroyPlayerHQ;

    [SerializeField]
    private Health _health;

    void OnEnable()
    {
        _health.OnDie += CheckDie;
    }

    private void CheckDie()
    {
        OnDestroyPlayerHQ?.Invoke();
    }
}
