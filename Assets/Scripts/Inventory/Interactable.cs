using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool IsWeapon { get { return _isWeapon; } }
    public Weapons GetWeapon { get { return _weapon; } }

    [SerializeField]
    private bool _isWeapon = false;
    [SerializeField]
    private Weapons _weapon = null;

    public bool isActivator = false;
    public CraftingActivator craftingActivator;
    public bool isInHands = false;

    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector3 position, Quaternion rotation)
    {
        _transform.position = position;
        _transform.rotation = rotation;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ground")
        {
            isInHands = false;
        }
    }
}