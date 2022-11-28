using Game_Service;
using Game_Service.Services;
using Game_User_Interface;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;
using Event = AK.Wwise.Event;

namespace Game_Management
{
    public class GameFinish : MonoBehaviour
    {
        [SerializeField] private GameEndUI gameEndUI;
        [SerializeField] private SceneIndexProvider mainMenuScene;
        [SerializeField] private Event winMusic;
        [SerializeField] private Event stopSounds;
        
        private void Start()
        {
            GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(HandleGameEnd);
        }

        private void HandleGameEnd(GameState gameState)
        {
            if (gameState == GameState.BystanderHit)
            {
                gameEndUI.ShowUI("You hit a bystander!");
                Lose();
            }
            else if (gameState == GameState.TargetHit)
            {
                gameEndUI.ShowUI("Mission Success. Target hit.");
                Win();
            }
            else if (gameState == GameState.OutOfTime)
            {
                gameEndUI.ShowUI("Out of time!");
                Lose();
            }
        }

        private void Win()
        {
            Time.timeScale = 0.2f;
            LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, LoadMainMenu);
            LeanTween.delayedCall(gameObject, 1.0f * Time.timeScale, StopSound);
            // winMusic.Post(gameObject);
        }

        private void Lose()
        {
            Time.timeScale = 0.2f;
            LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, ReloadScene);
            LeanTween.delayedCall(gameObject, 1.0f * Time.timeScale, StopSound);
        }

        private void StopSound()
        {
            stopSounds.Post(gameObject);
        }

        private void LoadMainMenu()
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene(mainMenuScene.Index);
        }

        private void ReloadScene()
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}