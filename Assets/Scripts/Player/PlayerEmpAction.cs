using Game_Service;
using Game_Service.Services;
using UnityEngine;
using Event = AK.Wwise.Event;

namespace Player
{
    public class PlayerEmpAction : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private Event empSoundEvent;
        
        private void Update()
        {
            var gameStateService = GameServiceProvider.GetService<IGameState>();
            if (playerInput.EmpInput)
            {
                DoEmp(gameStateService);
            }
        }

        private void DoEmp(IGameState gameStateService)
        {
            empSoundEvent.Post(gameObject);
            if (gameStateService.GameState == GameState.Setup)
            {
                gameStateService.GameState = GameState.EmpActivated;
            }
        }
    }
}