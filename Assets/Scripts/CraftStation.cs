using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CraftStation : MonoBehaviour
{
    public static event Action<CraftType> OnCraft;

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
        List<Collider> cretes = Physics.OverlapBox(transform.position, transform.localScale / 2, Quaternion.identity).Where(x => x.CompareTag("CraftingCrate")).ToList();
        foreach (var craftable in _craftableItems)
        {
            if (craftable.cratesToCraft <= cretes.Count)
            {
                itemToCraft = craftable;
            }
        }

        if (itemToCraft == null) return;

        Instantiate(itemToCraft.craftableObject, _spawnPoint.position, _spawnPoint.rotation);
        OnCraft?.Invoke(itemToCraft.type);
        for (int i = 0; i < itemToCraft.cratesToCraft; i++)
            Destroy(cretes[i].gameObject);
    }

    [System.Serializable]
    class CraftableItem
    {
        public GameObject craftableObject;
        public int cratesToCraft;
        public CraftType type;
    }    
}
