using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Util;

namespace Game_User_Interface
{
    public class LoadLevelButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private SceneIndexProvider levelToLoad;

        private void Start()
        {
            button.onClick.AddListener(LoadLevel);
        }

        private void LoadLevel()
        {
            LeanTween.delayedCall(gameObject, 0.2f, () =>
            {
                AkSoundEngine.StopAll();
                SceneManager.LoadScene(levelToLoad.Index);
            });
        }
    }
}