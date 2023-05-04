using UnityEngine;

public class SideManager : MonoBehaviour
{
    [SerializeField]
    private Side _side;

    public Side GetSide()
    {
        return _side;
    }
}