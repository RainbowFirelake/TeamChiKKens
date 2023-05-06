using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField]
    private Texture2D _cursorTexture;
    [SerializeField]
    private float _offset;

    void Start()
    {
        Cursor.SetCursor(_cursorTexture, new Vector2(_offset, _offset), CursorMode.Auto);
    }
}