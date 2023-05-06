using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    [SerializeField]
    private PickupTrigger _pickupTrigger;
    [SerializeField]
    private Transform _holdingObjectPoint;
    [SerializeField]
    private Shooter _shooter = null;

    private Transform _transform;
    private Interactable _currentItemInHands = null;
    private List<Interactable> _itemsAround;

    void Start()
    {
        _itemsAround = new List<Interactable>();
        _transform = GetComponent<Transform>();
    }

    void OnEnable()
    {
        _pickupTrigger.OnItemCheck += CheckForItemsAround;
        Health.OnChangeMan += FreeHands;
    }

    void OnDisable()
    {
        _pickupTrigger.OnItemCheck -= CheckForItemsAround;
        Health.OnChangeMan -= FreeHands;
    }

    void Update()
    {
        if (_currentItemInHands != null)
        {
            _currentItemInHands.SetPosition(_holdingObjectPoint.position, _transform.rotation);
        }
    }

    public void CheckForItemsAround(List<Interactable> itemsAround)
    {
        _itemsAround = itemsAround;
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
        foreach (var pickupable in _itemsAround)
        {
            var distance = (_transform.position - pickupable.GetPosition()).sqrMagnitude;
            //var distance = Vector3.Distance(_transform.position, pickupable.GetPosition());
            if (distance < minimalDistance * minimalDistance)
            {
                if (pickupable.isInHands) continue;
                nearestInteractable = pickupable;
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
            _itemsAround.Remove(nearestInteractable);
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
