using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftStation : MonoBehaviour
{
    [SerializeField]
    private List<CraftableItem> _craftableItems;
    [SerializeField]
    private Transform _spawnPoint = null;
    
    private int _currentNumberOfCrates;

    public void Craft()
    {
        foreach (var craftable in _craftableItems)
        {
            if (craftable.cratesToCraft == _currentNumberOfCrates)
            {
                Instantiate(craftable.craftableObject, _spawnPoint.position, _spawnPoint.rotation);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CraftingCrate")
        {
            _currentNumberOfCrates++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CraftingCrate")
        {
            _currentNumberOfCrates--;
        }
    }

    [System.Serializable]
    class CraftableItem
    {
        public GameObject craftableObject;
        public int cratesToCraft;
    }    
}
