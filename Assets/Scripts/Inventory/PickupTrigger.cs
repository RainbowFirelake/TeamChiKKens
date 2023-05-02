using UnityEngine;
using System;
using System.Collections.Generic;

public class PickupTrigger : MonoBehaviour
{
    public event Action<List<Interactable>> OnItemCheck;

    private List<Interactable> _itemsAround;

    void Start()
    {
        _itemsAround = new List<Interactable>();
    }

    void OnTriggerEnter(Collider other)
    {
        var pickupable = other.GetComponent<Interactable>();

        if (pickupable != null)
        {
            _itemsAround.Add(pickupable);
            OnItemCheck?.Invoke(_itemsAround);
        }
    }

    void OnTriggerExit(Collider other)
    {
        var pickupable = other.GetComponent<Interactable>();
        if (pickupable != null)
        {
            _itemsAround.Remove(pickupable);
            OnItemCheck?.Invoke(_itemsAround);
        }
    }
}