using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private RectTransform levelSelectionCanvas;
        [SerializeField] private Button button;
        
        private void Start()
        {
            button.onClick.AddListener(CloseLevelSelection);
        }

        private void CloseLevelSelection()
        {
            levelSelectionCanvas.gameObject.SetActive(false);
        }
    }
}