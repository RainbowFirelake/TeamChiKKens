using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 1f;
    private float _damage = 8f;
    private GameObject _impactEffect = null;
    private bool _isDamageImpactsOnArea = false;
    private float _damageArea = 0.1f;
    [SerializeField] float _lifeTime = 10.0f;

    private GameObject instigator = null;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void SetDamage(float damage)
    {
        this._damage = damage;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetImpactEffect(GameObject impactEffect)
    {
        _impactEffect = impactEffect;
    }

    public void SetAreaDamage(float damageArea)
    {
        _isDamageImpactsOnArea = true;
        _damageArea = damageArea;
    }

    private void AreaDamage()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _damageArea);
        foreach (var enemy in enemies)
        {
            var health = enemy.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(_damage);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Health reachedTarget = other.GetComponent<Health>();

        if (!reachedTarget) return;
        if (reachedTarget.IsDead()) return;

        if (_impactEffect != null)
            Instantiate(_impactEffect, transform.position, transform.rotation);
        if (_isDamageImpactsOnArea)
        {
            AreaDamage();
        }
        else 
        {
            reachedTarget.TakeDamage(_damage);
        }
        Destroy(gameObject);
    }

    void OnDrawGizmos()
    {
        if (!_isDamageImpactsOnArea) return;

        Gizmos.DrawSphere(transform.position, _damageArea);
    }
}
