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
    [SerializeField]
    private EffectSoundPlayer _impactSoundEffects;

    private bool _isActivated = false;
    private Side _side;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        if (_isActivated) return;
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

    public void SetImpactSounds(EffectSoundPlayer _sounds)
    {
        _impactSoundEffects = _sounds;
    }

    public void SetSide(Side side)
    {
        _side = side;
    }

    private void AreaDamage()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _damageArea);
        foreach (var enemy in enemies)
        {
            var health = enemy.GetComponent<Health>();
            if (health != null && _side != health.GetSide())
            {
                health.TakeDamage(_damage);
            }
        }
    }

    private void PlayImpactSound()
    {
        if (_impactSoundEffects != null)
        {
            var clip = _impactSoundEffects.GetRandomSound();
            ImpactSoundEffectPlayer.instance.PlayClipOnce(clip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isActivated) return;
        if (other.tag == "Ground")
        {
            if (_impactEffect != null)
            {
                Instantiate(_impactEffect, transform.position, transform.rotation);
            }

            if (_isDamageImpactsOnArea)
            {
                AreaDamage();
            }

            PlayImpactSound();

            _isActivated = true;
            Destroy(gameObject, 1.5f);
        }

        Health reachedTarget = other.GetComponent<Health>();

        if (!reachedTarget) return;
        if (reachedTarget.IsDead()) return;
        if (reachedTarget.GetSide() == _side) return;

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

        PlayImpactSound();

        _isActivated = true;
        Destroy(gameObject, 1.5f);
    }

    void OnDrawGizmos()
    {
        if (!_isDamageImpactsOnArea) return;

        Gizmos.DrawSphere(transform.position, _damageArea);
    }
}
