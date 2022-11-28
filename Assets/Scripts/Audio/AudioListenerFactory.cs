using System;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    public class AudioListenerFactory : MonoBehaviour
    {
        [SerializeField] private AudioListener audioListener;
        private void Start()
        {
            AudioListener existingListener = FindObjectOfType<AudioListener>();
            if (existingListener == null)
            {
                Instantiate(audioListener);
            }
        }
    }
}