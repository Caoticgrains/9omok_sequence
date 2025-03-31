using System;
using UnityEngine;

namespace System
{
    public class CustomCursor : MonoBehaviour
    {
        public Texture2D texture;
        public Vector2 hotspot = Vector2.zero;
        public CursorMode mode = CursorMode.Auto;

        void Start()
        {
            Cursor.SetCursor(texture, hotspot, mode);
        }
        
    }
}

