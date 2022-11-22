using System;
using Game_Service;
using Game_Service.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

namespace Game_User_Interface
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] private Button resumeButton;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private RectTransform pauseMenu;
        [SerializeField] private SceneIndexProvider menuScene;

        private void Start()
        {
            resumeButton.onClick.AddListener(Resume);
            restartButton.onClick.AddListener(Restart);
            quitButton.onClick.AddListener(Quit);
            pauseMenu.gameObject.SetActive(false);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private void Resume()
        {
            GameServiceProvider.GetService<IGamePauseService>().UnpauseGame();
            pauseMenu.gameObject.SetActive(false);
        }

        private void Quit()
        {
            SceneManager.LoadScene(menuScene.Index);
        }
    }
}