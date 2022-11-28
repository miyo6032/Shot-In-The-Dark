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
        [SerializeField] private Event breatheEvent;
        [SerializeField] private Animator animator;
        [SerializeField] private Animator uiAnimator;
        private static readonly int Emp = Animator.StringToHash("Emp");

        private void Update()
        {
            var gameStateService = GameServiceProvider.GetService<IGameState>();
            if (playerInput.EmpInput)
            {
                DoEmp(gameStateService);
            }
        }

        public void DoEmp(IGameState gameStateService)
        {
            if (gameStateService.GameState == GameState.Setup)
            {
                // LeanTween.delayedCall(gameObject, LightingHandler.FadeTime, () => breatheEvent.Post(gameObject));
                empSoundEvent.Post(gameObject);
                animator.SetTrigger(Emp);
                uiAnimator.SetTrigger(Emp);
                gameStateService.GameState = GameState.EmpActivated;
            }
        }
    }
}