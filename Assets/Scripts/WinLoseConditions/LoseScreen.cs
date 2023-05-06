using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public static LoseScreen instance;

    [SerializeField]
    private GameObject _loseScreen;
    [SerializeField]
    private float _timeToReloadScene = 2f;
    [SerializeField]
    private bool _cantLose = false;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Lose()
    {
        if(!_cantLose)
        {
            Debug.Log("lose");
            _loseScreen.SetActive(true);
            StartCoroutine(ReloadCoroutine());
        }
    }

    public void DisableLose()
    {
        _cantLose = false;
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(_timeToReloadScene);
        SceneManager.LoadScene(0);
    }
}
