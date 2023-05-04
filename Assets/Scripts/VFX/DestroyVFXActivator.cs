using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyVFXActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject _vfx;
    [SerializeField]
    private Transform _transformToInstantiate;
    [SerializeField]
    private Health _health;
    [SerializeField]
    private float _delay = 0.5f;

    void Start()
    {
        if (_transformToInstantiate == null)
        {
            _transformToInstantiate = transform;
        }
    }

    void OnEnable()
    {
        _health.OnDie += CreateVFX;
    }

    private void CreateVFX()
    {
        StartCoroutine(DelayCreate());
    }

    private IEnumerator DelayCreate()
    {
        yield return new WaitForSeconds(_delay);
        Instantiate(_vfx, _transformToInstantiate.position, transform.rotation);
    }
}
