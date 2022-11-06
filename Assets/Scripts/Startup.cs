using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace DefaultNamespace
{
    public class Startup : MonoBehaviour
    {
        private void Awake()
        {
            GameServiceProvider.RegisterServices(new BackendServices(new GameStateManager()));
        }
    }
}