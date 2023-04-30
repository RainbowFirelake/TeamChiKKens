using UnityEngine;

public class Pickupable : MonoBehaviour
{
    private bool _isPickuped = false;
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
}