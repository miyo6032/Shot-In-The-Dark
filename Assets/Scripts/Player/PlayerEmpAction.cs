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
            if (playerInput.EmpInput && gameStateService.GameState == GameState.Setup)
            {
                Debug.Log("Emp Activated");
                gameStateService.GameState = GameState.Emp;
            }
        }
    }
}