using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private float _shootDistance;
    [SerializeField]
    private Shooter _shooter;
    [SerializeField]
    private SideManager _side;
    [SerializeField]
    private float _updateTime = 0.3f;

    private Transform _enemyPosition;
    private float _yDelta;

    void Start()
    {
        _yDelta = transform.localScale.y + transform.position.y;
        StartCoroutine(StartCheck());
    }

    void Update()
    {
        if (_enemyPosition != null)
        {
            var vector = new Vector3(_enemyPosition.position.x, _yDelta, _enemyPosition.position.z);
            _shooter.SetAimDirection(vector);
            _shooter.Shoot();
        }
    }

    private IEnumerator StartCheck()
    {
        while (true)
        {
            CheckEnemies();
            yield return new WaitForSeconds(_updateTime);
        }
    }

    private void CheckEnemies()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _shootDistance);
        foreach (var enemy in enemies)
        {
            var side = enemy.GetComponent<SideManager>();
            if (side != null && side.GetSide() != _side.GetSide())
            {
                _enemyPosition = side.transform;
            }
        }
    }
}
