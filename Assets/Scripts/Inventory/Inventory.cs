using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private PickupTrigger _pickupTrigger;
    [SerializeField]
    private Transform _holdingObjectPoint;
    [SerializeField]
    private Shooter _shooter = null;
    [SerializeField]
    private float _radius = 3f;
    private Transform _transform;
    private Interactable _currentItemInHands = null;

    void Start()
    {
        _transform = GetComponent<Transform>();
        StartCoroutine(MoveCreate());
    }

    void OnEnable()
    {
        Health.OnChangeMan += FreeHands;
    }

    void OnDisable()
    {
        Health.OnChangeMan -= FreeHands;
    }

    IEnumerator MoveCreate()
    {
        while (true)
        {

            if (_currentItemInHands != null)
            {
                _currentItemInHands.SetPosition(_holdingObjectPoint.position, _transform.rotation);
            }
            yield return new WaitForSecondsRealtime(0.001f);
        }
    }

    public void Unpickup()
    {
        if (_currentItemInHands != null)
        {
            _currentItemInHands.isInHands = false;
            _currentItemInHands = null;
        }
    }

    public void Pickup()
    {
        if (_currentItemInHands != null)
        {
            _currentItemInHands.isInHands = false;
            _currentItemInHands = null;
            return;
        }

        var minimalDistance = 4f;
        Interactable nearestInteractable = null;
        List<Collider> _itemsAround = Physics.OverlapSphere(transform.position, _radius).Where(x => x.GetComponent<Interactable>() != null).ToList();
        foreach (var pickupable in _itemsAround)
        {
            var pick = pickupable.GetComponent<Interactable>();
            var distance = (_transform.position - pick.GetPosition()).sqrMagnitude;
            //var distance = Vector3.Distance(_transform.position, pickupable.GetPosition());
            if (distance < minimalDistance * minimalDistance)
            {
                if (pick.isInHands) continue;
                nearestInteractable = pick;
                minimalDistance = distance;
            }
        }

        if (nearestInteractable != null && nearestInteractable.isActivator)
        {
            Debug.Log("Crafting");
            nearestInteractable.craftingActivator.DoCraft();
            return;
        }

        if (_shooter != null && nearestInteractable != null && nearestInteractable.IsWeapon)
        {
            _shooter.EquipWeapon(nearestInteractable.GetWeapon);
            Destroy(nearestInteractable.gameObject);
            return;
        }

        if (nearestInteractable != null)
        {
            nearestInteractable.isInHands = true;
            _currentItemInHands = nearestInteractable;
        }
    }

    public bool isItemInHands()
    {
        return _currentItemInHands != null;
    }

    public void FreeHands()
    {
        _currentItemInHands = null;
    }
}
