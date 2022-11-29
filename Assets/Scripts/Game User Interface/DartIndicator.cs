using System;
using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Game_User_Interface
{
    public class DartIndicator : MonoBehaviour
    {
        [SerializeField] private RectTransform indicator;

        private void Start()
        {
            indicator.gameObject.SetActive(false);
            GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(ShowIndicator);
        }

        private void ShowIndicator(GameState obj)
        {
            if (obj == GameState.IsDark)
            {
                indicator.gameObject.SetActive(true);
            }
        }
    }
}