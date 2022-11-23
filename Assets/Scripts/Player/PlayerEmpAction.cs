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
        [SerializeField] private Animator animator;
        private static readonly int Emp = Animator.StringToHash("Emp");

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
            if (gameStateService.GameState == GameState.Setup)
            {
                empSoundEvent.Post(gameObject);
                animator.SetTrigger(Emp);
                gameStateService.GameState = GameState.EmpActivated;
            }
        }
    }
}