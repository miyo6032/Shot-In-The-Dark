using System;
using UnityEngine;
using UnityEngine.UI;
using Event = AK.Wwise.Event;

namespace Game_User_Interface
{
    public class ButtonSound : MonoBehaviour
    {
        [SerializeField] private Event clickSound;
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(PlayClickSound);
        }

        private void PlayClickSound()
        {
            clickSound.Post(gameObject);
        }
    }
}