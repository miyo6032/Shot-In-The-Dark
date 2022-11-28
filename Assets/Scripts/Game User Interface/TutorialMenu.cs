using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game_User_Interface
{
    public class TutorialMenu : MonoBehaviour
    {
        [SerializeField] private TutorialSlide[] tutorials;
        [SerializeField] private Button nextButton;
        [SerializeField] private Button previousButton;
        [SerializeField] private RectTransform tutorialMenu;
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private Image image;
        
        private int slideProgress;

        private void Start()
        {
            HideTutorialMenu();
            nextButton.onClick.AddListener(NextSlideOrClose);
            previousButton.onClick.AddListener(PrevSlideOrClose);
        }

        public void ShowTutorialMenu()
        {
            tutorialMenu.gameObject.SetActive(true);
            slideProgress = 0;
            UpdateSlide();
        }

        private void HideTutorialMenu()
        {
            tutorialMenu.gameObject.SetActive(false);
        }

        private void NextSlideOrClose()
        {
            if (slideProgress >= tutorials.Length - 1)
            {
                HideTutorialMenu();
                return;
            }

            slideProgress++;
            UpdateSlide();
        }

        private void UpdateSlide()
        {
            image.sprite = tutorials[slideProgress].sprite;
            text.text = tutorials[slideProgress].caption;
        }

        private void PrevSlideOrClose()
        {
            if (slideProgress <= 0)
            {
                HideTutorialMenu();
                return;
            }

            slideProgress--;
            UpdateSlide();
        }
    }

    [Serializable]
    public class TutorialSlide
    {
        public Sprite sprite;
        public string caption;
    }
}