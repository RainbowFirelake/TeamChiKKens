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
            bool hasColliders = Physics.OverlapBox(spawnZone.transform.position, spawnZone.transform.localScale / 2 , Quaternion.identity).Any(x => x.CompareTag("CraftingCrate"));
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
        while (Vector3.Distance(transform.position, spawnZone.transform.position) >= 3f)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("PickUp");
        _inventory.Pickup();
        yield return new WaitForSeconds(0.2f);
        if (_inventory.isItemInHands())
        {
            yield return new WaitForSeconds(0.1f);
            _agent.SetDestination(_base.transform.position);

            while (Vector3.Distance(transform.position, _base.position) >= 2f)
            {
                yield return new WaitForSeconds(0.1f);
            }

            _inventory.Pickup();
            yield return new WaitForSeconds(0.1f);
        }
        _isWorking = false;
    }


}
