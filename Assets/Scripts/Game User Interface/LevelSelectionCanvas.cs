using System;
using UnityEngine;

namespace Game_User_Interface
{
    public class LevelSelectionCanvas : MonoBehaviour
    {
        [SerializeField] private RectTransform levelSelectionCanvas;

        private void Start()
        {
            levelSelectionCanvas.gameObject.SetActive(false);
        }
    }
}