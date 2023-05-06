using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerActivator : MonoBehaviour
{
    [SerializeField] 
    private float _timer;
    [SerializeField]
    private GameObject _spawner;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivateDelay());
    }

    private IEnumerator ActivateDelay()
    {
        yield return new WaitForSeconds(_timer);
        _spawner.SetActive(true);
    }
}
