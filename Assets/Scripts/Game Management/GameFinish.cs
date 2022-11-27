using Game_Service;
using Game_Service.Services;
using Game_User_Interface;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Game_Management
{
    public class GameFinish : MonoBehaviour
    {
        [SerializeField] private GameEndUI gameEndUI;
        [SerializeField] private SceneIndexProvider mainMenuScene;
        private void Start()
        {
            GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(HandleGameEnd);
        }

        private void HandleGameEnd(GameState gameState)
        {
            if (gameState == GameState.BystanderHit)
            {
                gameEndUI.ShowUI("You hit a bystander!");
                Time.timeScale = 0.2f;
                LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, ReloadScene);
            }
            else if (gameState == GameState.TargetHit)
            {
                gameEndUI.ShowUI("Mission Success. Target hit.");
                Time.timeScale = 0.2f;
                LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, LoadMainMenu);
            }
            else if (gameState == GameState.OutOfTime)
            {
                gameEndUI.ShowUI("Out of time!");
                Time.timeScale = 0.2f;
                LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, ReloadScene);
            }
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene(mainMenuScene.Index);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}