using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScripatble : MonoBehaviour
{
    [SerializeField]
    typeEnemy type;
    enum typeEnemy { 
        Osada,
        Killer
    }

    private Shooter _shoter;
    private Movement _movement;
    [SerializeField]
    private float radius_attack;
    [SerializeField]
    private float radius_chase;
    private NavMeshAgent _agent;
    private Vector3 _base_pos;
    private void Start()
    {
        _base_pos =  GameObject.FindGameObjectWithTag("Base").transform.position;
        _shoter = GetComponent<Shooter>();
        _agent = GetComponent<NavMeshAgent>();
        _movement = GetComponent<Movement>(); 
    }

    private void Update()
    {
        Collider collider = Physics.OverlapSphere(transform.position, radius_chase).Where(x => x.CompareTag("Player")).FirstOrDefault();
        if (collider != null)
        {
            Debug.Log(collider.tag);
            _agent.SetDestination(collider.transform.position);
            if (Vector3.Distance(transform.position, collider.transform.position) <= radius_attack)
            {
                _shoter.SetAimDirection(collider.transform.position);
                _shoter.Shoot();
            }
        }
        else if (Vector3.Distance(transform.position, _base_pos) >= radius_attack - 10)
            _agent.SetDestination(_base_pos);
    }

}
