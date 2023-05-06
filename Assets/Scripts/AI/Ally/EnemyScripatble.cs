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
    [SerializeField]
    private float radius_attack;
    [SerializeField]
    private float radius_chase;
    private NavMeshAgent _agent;
    private Vector3 _base_pos;

    private Transform _curretTarget;
    private void Start()
    {
        _base_pos =  GameObject.FindGameObjectWithTag("Base").transform.position;
        _shoter = GetComponent<Shooter>();
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(CheckPlayer());
    }

    IEnumerator CheckPlayer()
    {
        while (true)
        {
            Collider collider = Physics.OverlapSphere(transform.position, radius_chase).Where(x => x.CompareTag("Player")).FirstOrDefault();
            if (collider != null)
            {
                if (Vector3.Distance(transform.position, collider.transform.position) <= radius_attack)
                {
                    _agent.SetDestination(transform.position);
                }
                else
                {
                    Debug.Log("Distance: " + Vector3.Distance(transform.position, collider.transform.position));
                    _agent.SetDestination(collider.transform.position);
                    _curretTarget = collider.transform;
                }
            }
            else if (Vector3.Distance(transform.position, _base_pos) >= radius_attack * 0.8f)
            {
                _agent.SetDestination(_base_pos); 
                _curretTarget = null;
            }
            else
            {
                _curretTarget = null;
                _agent.SetDestination(transform.position);
            }
            yield return new WaitForSecondsRealtime(0.3f);
        }
    }

    private void Update()
    {
        if(_curretTarget != null && Vector3.Distance(transform.position, GetComponent<Collider>().transform.position) <= radius_attack)
        {
            _shoter.SetAimDirection(_curretTarget.position);
            _shoter.Shoot();
        }
        else if(Vector3.Distance(transform.position, _base_pos) <= radius_attack * 0.8f)
        {
            _shoter.SetAimDirection(_base_pos);
            _shoter.Shoot();
        }
    }

}
