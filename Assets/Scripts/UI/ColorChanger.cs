using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField]
    private CraftingActivator _craftingActivator;
    [SerializeField]
    private TMPro.TMP_Text _text;
    [SerializeField] 
    private Color _color;

    private Color _baseColor;

    void Start()
    {
        _baseColor = _text.color;
    }

    void OnEnable()
    {
        _craftingActivator.OnCraft += ChangeColor;
    }

    private void ChangeColor()
    {
        StartCoroutine(ChangeColorCoroutine());
    }   

    private IEnumerator ChangeColorCoroutine()
    {
        _text.color = _color;
        yield return new WaitForSeconds(0.2f);
        _text.color = _baseColor;
    }
}