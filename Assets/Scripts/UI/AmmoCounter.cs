using UnityEngine;

public class AmmoCounter : MonoBehaviour
{
    [SerializeField]
    private Shooter _playerShooter;
    [SerializeField]
    private TMPro.TMP_Text ammoCount;

    void OnEnable()
    {
        _playerShooter.OnAmmoCountUpdate += UpdateAmmoCount;
    }

    public void UpdateAmmoCount(int count)
    {
        ammoCount.text = "Патроны: " + count;
    }
}