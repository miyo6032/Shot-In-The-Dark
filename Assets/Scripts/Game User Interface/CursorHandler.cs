using System;
using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Game_User_Interface
{
    public class CursorHandler : MonoBehaviour
    {
        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;
        private void Start()
        {
            GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(SetCursor);
        }

        private void SetCursor(GameState gameState)
        {
            if (gameState == GameState.IsDark)
            {
                Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
            }
        }
    }
}