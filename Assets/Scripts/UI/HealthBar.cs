using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Image _fillBar;
    [SerializeField]
    private Text _text;
    [SerializeField]
    private Health _playerHealth;

    private float maxHealth;

    void OnEnable()
    {
        _playerHealth.OnUpdateHealth += UpdateBar;
        maxHealth = _playerHealth.GetMaxHealth();
        UpdateBar(maxHealth);
    }

    void OnDisable()
    {
        _playerHealth.OnUpdateHealth -= UpdateBar;
    }

    private void UpdateBar(float hp)
    {
        _text.text = Mathf.FloorToInt(hp).ToString();
        _fillBar.fillAmount = hp/maxHealth;
    }
}