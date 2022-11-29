using TMPro;
using UnityEngine;

namespace Game_User_Interface
{
    public class GameEndUI : MonoBehaviour
    {
        [SerializeField] private RectTransform mainCanvas;
        [SerializeField] private TextMeshProUGUI messageText;
        
        public void ShowUI(string message)
        {
            messageText.text = message;
            mainCanvas.gameObject.SetActive(true);
        }

        public void HideUI()
        {
            mainCanvas.gameObject.SetActive(false);
        }
    }
}