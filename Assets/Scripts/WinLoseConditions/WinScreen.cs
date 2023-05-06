using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public static WinScreen instance;

    [SerializeField]
    private GameObject _winScreen;
    [SerializeField]
    private float _timeToReloadScene = 2f;

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

    public void Win()
    {
        Debug.Log("win");
        _winScreen.SetActive(true);
        LoseScreen.instance.DisableLose();
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(_timeToReloadScene);
        SceneManager.LoadScene(2);
    }
}