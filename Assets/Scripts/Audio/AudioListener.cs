using System;
using UnityEngine;

namespace DefaultNamespace.Audio
{
    public class AudioListener : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}