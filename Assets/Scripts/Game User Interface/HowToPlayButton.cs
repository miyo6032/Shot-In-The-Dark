using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class HowToPlayButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private TutorialMenu tutorialMenu;
        
        private void Start()
        {
            button.onClick.AddListener(LoadTutorial);
        }
        
        private void LoadTutorial()
        {
            tutorialMenu.ShowTutorialMenu();
        }
    }
}