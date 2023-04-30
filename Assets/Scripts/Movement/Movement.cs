using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent _agent;
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public void Move(float x, float z)
    {
        if (x != 0 || z != 0)
        {
            var moveDirection = new Vector3(x, 0, z);
            var movePosition = _transform.position + moveDirection;
            _agent.SetDestination(movePosition);
        }
        else
        {
            _agent.SetDestination(_transform.position);
        }
    }
}
