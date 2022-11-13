using Game_Service;
using Game_Service.Services;
using Player;
using Timer;
using UnityEngine;

namespace DefaultNamespace
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private CountdownTimer countdownTimer;
        [SerializeField] private LightingHandler lightingHandler;
        
        private void Awake()
        {
            GameServiceProvider.RegisterServices(new BackendServices(new GameStateManager(), countdownTimer));
            FrontEndServiceProvider.RegisterServices(new FrontEndServices(lightingHandler));
            
            GameServiceProvider.GetService<IGameTimer>().SetTimer(15, OnTimerOut, f => $"{f:0} seconds to make shot");
            // GameServiceProvider.GetService<IGameTimer>().SetTimer(10, DoEmp, f => $"{f:0} seconds until EMP");
        }
        
        private static void OnTimerOut()
        {
            if (GameServiceProvider.GetService<IGameState>().GameState == GameState.IsDark)
            {
                Debug.Log("Timer ran out");
            }
        }

        // private void DoEmp()
        // {
            // PlayerEmpAction.DoEmp(GameServiceProvider.GetService<IGameState>());
        // }
    }
}