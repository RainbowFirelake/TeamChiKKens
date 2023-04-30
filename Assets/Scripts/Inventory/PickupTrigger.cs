using UnityEngine;
using System;
using System.Collections.Generic;

public class PickupTrigger : MonoBehaviour
{
    public event Action<List<Pickupable>> OnItemCheck;

    private List<Pickupable> _itemsAround;

    void Start()
    {
        _itemsAround = new List<Pickupable>();
    }

    void OnTriggerEnter(Collider other)
    {
        var pickupable = other.GetComponent<Pickupable>();

        if (pickupable != null)
        {
            _itemsAround.Add(pickupable);
            OnItemCheck?.Invoke(_itemsAround);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var pickupable = other.GetComponent<Pickupable>();
        if (pickupable != null)
        {
            _itemsAround.Remove(pickupable);
            OnItemCheck?.Invoke(_itemsAround);
        }
    }
}