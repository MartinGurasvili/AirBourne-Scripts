using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{
    // Start is called before the first frame update
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public Texture2D cursorTexture;
    void Start()
    {
        //cursorTexture.Resize((cursorTexture.width) / 3,(cursorTexture.height) / 3);

        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

}
