using Game_Service;
using Game_Service.Services;
using Timer;
using UnityEngine;
using Util;

namespace DefaultNamespace
{
    public class Startup : MonoBehaviour
    {
        [SerializeField] private CountdownTimer countdownTimer;
        [SerializeField] private LightingHandler lightingHandler;
        
        private void Awake()
        {
            Time.timeScale = 1.0f;
            GameServiceProvider.RegisterServices(new BackendServices(new GameStateManager(), countdownTimer));
            FrontEndServiceProvider.RegisterServices(new FrontEndServices(lightingHandler));
            
            GameServiceProvider.GetService<IGameTimer>().SetTimer(30, OnTimerOut, f => $"{f:0} seconds to make shot");
            // GameServiceProvider.GetService<IGameTimer>().SetTimer(10, DoEmp, f => $"{f:0} seconds until EMP");
        }
        
        private static void OnTimerOut()
        {
            if (!GameServiceProvider.GetService<IGameState>().GameState.Contains(GameState.TargetHit, GameState.TargetHit, GameState.BystanderHit))
            {
                GameServiceProvider.GetService<IGameState>().GameState = GameState.OutOfTime;
            }
        }

        // private void DoEmp()
        // {
            // PlayerEmpAction.DoEmp(GameServiceProvider.GetService<IGameState>());
        // }
    }
}