using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Player
{
    public class PlayerEmpAction : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        
        private void Update()
        {
            var gameStateService = GameServiceProvider.GetService<IGameState>();
            if (playerInput.EmpInput)
            {
                DoEmp(gameStateService);
            }
        }

        public static void DoEmp(IGameState gameStateService)
        {
            if (gameStateService.GameState == GameState.Setup)
            {
                Debug.Log("Emp Activated");
                gameStateService.GameState = GameState.Emp;
                GameServiceProvider.GetService<IGameTimer>().SetTimer(5, OnTimerOut, f => $"{f:0} seconds to make shot");
            }
        }

        private static void OnTimerOut()
        {
            if (GameServiceProvider.GetService<IGameState>().GameState == GameState.Emp)
            {
                Debug.Log("Timer ran out");
            }
        }
    }
}