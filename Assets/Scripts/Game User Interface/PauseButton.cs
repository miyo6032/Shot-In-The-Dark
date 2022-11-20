using System;
using Game_Service;
using Game_Service.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private RectTransform pauseMenu;
        private void Start()
        {
            button.onClick.AddListener(PauseMenu);
        }

        private void PauseMenu()
        {
            var gamePauseService = GameServiceProvider.GetService<IGamePauseService>();
            pauseMenu.gameObject.SetActive(true);
            gamePauseService.PauseGame();
        }
    }
}