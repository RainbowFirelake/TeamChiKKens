using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _panel;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            EnableDisable();
        }
    }

    public void EnableDisable()
    {
        _panel.SetActive(!_panel.activeSelf);
    }
}
