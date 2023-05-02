using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingActivator : MonoBehaviour
{
    [SerializeField] 
    private CraftStation _craftStation;
    
    public void DoCraft()
    {
        _craftStation.Craft();
    }
}
