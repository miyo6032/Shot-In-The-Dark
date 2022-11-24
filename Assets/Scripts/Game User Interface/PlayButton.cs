using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

namespace Game_User_Interface
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private RectTransform levelSelectionCanvas;

        private void Start()
        {
            button.onClick.AddListener(LoadFirstLevel);
        }

        private void LoadFirstLevel()
        {
            levelSelectionCanvas.gameObject.SetActive(true);
        }
    }
}