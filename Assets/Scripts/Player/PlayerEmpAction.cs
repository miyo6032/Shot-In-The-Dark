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
                gameStateService.GameState = GameState.Emp;
            }
        }
    }
}