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
    private float _pickupDistance = 3f;

    private Transform _transform;
    private Pickupable _currentItemInHands = null;
    private List<Pickupable> _itemsAround;

    void Start()
    {
        _itemsAround = new List<Pickupable>();
        _transform = GetComponent<Transform>();
    }

    void OnEnable()
    {
        _pickupTrigger.OnItemCheck += CheckForItemsAround;
    }

    void OnDisable()
    {
        _pickupTrigger.OnItemCheck -= CheckForItemsAround;
    }

    void Update()
    {
        if (_currentItemInHands != null)
        {
            _currentItemInHands.SetPosition(_holdingObjectPoint.position, _transform.rotation);
        }
    }

    public void CheckForItemsAround(List<Pickupable> itemsAround)
    {
        _itemsAround = itemsAround;
    }

    public void Pickup()
    {
        if (_currentItemInHands != null)
        {
            _currentItemInHands = null;
            return;
        }

        var minimalDistance = 4f;
        Pickupable nearestPickupable = null;
        foreach (var pickupable in _itemsAround)
        {
            var distance = (_transform.position - pickupable.GetPosition()).sqrMagnitude;
            //var distance = Vector3.Distance(_transform.position, pickupable.GetPosition());
            if (distance < minimalDistance * minimalDistance)
            {
                nearestPickupable = pickupable;
                minimalDistance = distance;
            }
        }

        if (nearestPickupable != null)
        {
            _currentItemInHands = nearestPickupable;
        }
    }
}
