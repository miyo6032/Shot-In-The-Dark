using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class QuitButton : MonoBehaviour
    {
        [SerializeField] private Button quitButton;

        private void Start()
        {
            quitButton.onClick.AddListener(Quit);
        }
        
        private void Quit()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }
}