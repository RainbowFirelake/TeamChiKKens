using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float damage = 8f;
    [SerializeField] GameObject impactEffect = null;
    [SerializeField] float lifeTime = 20.0f;

    private GameObject instigator = null;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit");
        Health reachedTarget = other.GetComponent<Health>();

        if (!reachedTarget) return;
        if (reachedTarget.IsDead()) return;

        if (impactEffect != null)
            Instantiate(impactEffect, transform.position, transform.rotation);

        reachedTarget.TakeDamage(instigator, damage);
        Destroy(gameObject);
    }
}
