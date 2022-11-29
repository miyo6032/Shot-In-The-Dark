using Game_Service;
using Game_Service.Services;
using Game_User_Interface;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Util;
using Event = AK.Wwise.Event;

namespace Game_Management
{
    public class GameFinish : MonoBehaviour
    {
        [SerializeField] private GameEndUI gameEndUI;
        [SerializeField] private CanvasGroup blackoutPanel;
        [SerializeField] private CanvasGroup dragVisuals;
        [FormerlySerializedAs("mainMenuScene")] [SerializeField] private SceneIndexProvider sceneAfterWin;
        [SerializeField] private Event winMusic;
        [SerializeField] private Animator animator;
        [SerializeField] private Image dragImage;
        [SerializeField] private Image dragShirtImage;
        [SerializeField] private Image dragPantsImage;
        private static readonly int Hit = Animator.StringToHash("Hit");

        private void Start()
        {
            GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(HandleGameEnd);
            blackoutPanel.alpha = 0f;
            blackoutPanel.blocksRaycasts = false;
            gameEndUI.HideUI();
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
                gameEndUI.ShowUI("Target Neutralized.");
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
            LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, ShowWinningSequence);
            LeanTween.delayedCall(gameObject, 6.0f * Time.timeScale, LoadNextScene);
        }

        private void ShowWinningSequence()
        {
            AkSoundEngine.StopAll();
            winMusic.Post(gameObject);
            blackoutPanel.alpha = 0f;
            var brightness = 0.6f;
            dragImage.color = FrontEndServiceProvider.GetService<IColorService>().GetTargetSkinColor() * brightness;
            dragShirtImage.color = FrontEndServiceProvider.GetService<IColorService>().GetTargetColor() * brightness;
            dragPantsImage.color = new Color(brightness, brightness, brightness, 1.0f);
            gameEndUI.ShowUI("Mission Success.");
            blackoutPanel.blocksRaycasts = true;
            LeanTween.value(gameObject, f => blackoutPanel.alpha = f, 0.0f, 1.0f, 0.5f * Time.timeScale);
            LeanTween.value(gameObject, f => dragVisuals.alpha = f, 1.0f, 0.0f, 1.0f * Time.timeScale).setDelay(1.0f * Time.timeScale);
            StartAnimation();
        }

        private void StartAnimation()
        {
            animator.SetTrigger(Hit);
        }

        private void Lose()
        {
            Time.timeScale = 0.2f;
            LeanTween.delayedCall(gameObject, 2.0f * Time.timeScale, ReloadScene);
        }

        private void LoadNextScene()
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene(sceneAfterWin.Index);
        }

        private void ReloadScene()
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}