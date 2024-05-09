using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseChanger : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorTexture;

    private void Start()
    {
        SetCursorIcon();
    }

    private void SetCursorIcon()
    {
        Cursor.SetCursor(_cursorTexture, new Vector2(_cursorTexture.width * 0.5f, _cursorTexture.height * 0.5f), CursorMode.Auto);
    }
}