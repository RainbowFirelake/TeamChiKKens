using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;

    private Camera mainCamera;
    private NavMeshAgent agent;

    private void Start() {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        if (x != 0 || z != 0)
        {
            var moveDirection = new Vector3(x, 0, z);
            var movePosition = transform.position + moveDirection;
            
            agent.SetDestination(movePosition);
        }
        else 
        {
            agent.SetDestination(transform.position);
        }
        var rayFromCamera = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayFromCamera, out var hit))
        {
            var hitPointWithCharY = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(hitPointWithCharY);
        }
    }
}
