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
        
        private void Awake()
        {
            GameServiceProvider.RegisterServices(new BackendServices(new GameStateManager(), countdownTimer));
            
            GameServiceProvider.GetService<IGameTimer>().SetTimer(10, DoEmp, f => $"{f:0} seconds until EMP");
        }

        private void DoEmp()
        {
            PlayerEmpAction.DoEmp(GameServiceProvider.GetService<IGameState>());
        }
    }
}