using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util;

namespace Game_User_Interface
{
    public class MissionTitle : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private SceneIndexProvider nextScene;

        private void Start()
        {
            Time.timeScale = 1.0f;
            LeanTween
                .value(gameObject, f => canvasGroup.alpha = f, 0.0f, 1.0f, 0.5f)
                .setOnComplete(() =>
                {
                    LeanTween
                        .value(gameObject, f => canvasGroup.alpha = f, 1.0f, 0.0f, 0.5f)
                        .setDelay(1.0f)
                        .setOnComplete(NextScene);
                });
        }

        private void NextScene()
        {
            AkSoundEngine.StopAll();
            SceneManager.LoadScene(nextScene.Index);
        }
    }
}