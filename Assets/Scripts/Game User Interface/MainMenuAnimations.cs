using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class MainMenuAnimations : MonoBehaviour
    {
        [SerializeField] private Image backgroundPanel;
        [SerializeField] private CanvasGroup mainMenu;

        private void Start()
        {
            LeanTween.value(gameObject, f => mainMenu.alpha = f, 0.0f, 1.0f, 1.0f);
            backgroundPanel.color = Color.black;
            LeanTween.value(gameObject, f => backgroundPanel.color = new Color(f, f, f, 1.0f), 0.0f, 1.0f, 1.0f).setDelay(1.0f);
        }
    }
}