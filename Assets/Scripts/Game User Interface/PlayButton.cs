using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

namespace Game_User_Interface
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private SceneIndexProvider firstLevelScene;
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(LoadFirstLevel);
        }

        private void LoadFirstLevel()
        {
            LeanTween.delayedCall(gameObject, 0.2f, () =>
            {
                SceneManager.LoadScene(firstLevelScene.Index);
            });
        }
    }
}