using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TaskManager : MonoBehaviour
{

    List<GameObject> _spawnZones;
    Transform _base;
    NavMeshAgent _agent;
    Inventory _inventory;
    bool _isWorking =false; 
    // Start is called before the first frame update
    void Start()
    {
        _spawnZones = GameObject.FindGameObjectsWithTag("SpawnZone").
                     OrderBy(x => (x.transform.position - transform.position).magnitude).ToList();
        _base = GameObject.FindGameObjectWithTag("WorkingStation").transform;
        _agent = GetComponent<NavMeshAgent>();
        _inventory = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_isWorking)
        foreach (GameObject spawnZone in _spawnZones)
        {
            bool hasColliders = Physics.CheckBox(spawnZone.transform.position, spawnZone.transform.localScale / 2);
            if (hasColliders)
            {
                _isWorking = true;
                    StartCoroutine(CompleateTask(spawnZone));
                    break;
            }
        }

    }

    IEnumerator CompleateTask(GameObject spawnZone)
    {
        _agent.SetDestination(spawnZone.transform.position);
        while (_agent.remainingDistance > _agent.stoppingDistance)
        {
            yield return null;
        }

        _inventory.Pickup();

        _agent.SetDestination(_base.transform.position);
        while (_agent.remainingDistance > _agent.stoppingDistance)
        {
            yield return null;
        }

        _inventory.Pickup();

        _isWorking = false;
    }


}
