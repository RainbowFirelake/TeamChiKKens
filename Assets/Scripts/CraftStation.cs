using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftStation : MonoBehaviour
{
    [SerializeField]
    private List<CraftableItem> _craftableItems;
    [SerializeField]
    private Transform _spawnPoint = null;

    private List<GameObject> _crates = null;

    void Start()
    {
        _crates = new List<GameObject>();
    }

    public void Craft()
    {
        CraftableItem itemToCraft = null;
        foreach (var craftable in _craftableItems)
        {
            if (craftable.cratesToCraft <= _crates.Count)
            {
                itemToCraft = craftable;
            }
        }

        if (itemToCraft == null) return;

        Instantiate(itemToCraft.craftableObject, _spawnPoint.position, _spawnPoint.rotation);
        DestroyCrates(itemToCraft.cratesToCraft);
    }

    private void DestroyCrates(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _crates[i].SetActive(false);
        }

        _crates.RemoveRange(0, count);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CraftingCrate")
        {
            _crates.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "CraftingCrate")
        {
            _crates.Remove(other.gameObject);
        }
    }

    [System.Serializable]
    class CraftableItem
    {
        public GameObject craftableObject;
        public int cratesToCraft;
    }    
}
