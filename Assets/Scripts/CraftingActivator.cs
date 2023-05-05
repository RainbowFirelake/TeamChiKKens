using UnityEngine;
using System;

public class CraftingActivator : MonoBehaviour
{
    public event Action OnCraft;

    [SerializeField] 
    private CraftStation _craftStation;
    
    public void DoCraft()
    {
        _craftStation.Craft();
        OnCraft?.Invoke();
    }
}
