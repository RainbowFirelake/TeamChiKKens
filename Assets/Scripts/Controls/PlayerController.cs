using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3f;

    [SerializeField]
    private Movement _movement;
    [SerializeField]
    private Shooter _shooter;
    [SerializeField]
    private Inventory _inventory;
    [SerializeField]
    private LayerMask _maskForAiming;

    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");

        _movement.Move(x, z);
        
        if (Input.GetMouseButton(0))
        {
            _shooter.Shoot();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            _inventory.Pickup();
        }

        var rayFromCamera = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(rayFromCamera, out var hit, 100f, _maskForAiming))
        {
            var hitPointWithCharY = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.LookAt(hitPointWithCharY);
        }
    }
}
