using Game_Service;
using Game_Service.Services;
using UnityEngine;
using Util;

namespace Level_Objects
{
    public class TranslateObject : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private Vector2 translation;
        private static readonly int Speed = Animator.StringToHash("Speed");

        public void Init(Vector2 trans)
        {
            translation = trans;
            animator.SetFloat(Speed, 1.0f);
        }

        private void FixedUpdate()
        {
            if (GameServiceProvider.GetService<IGameState>().GameState.Contains(GameState.TargetHit, GameState.BystanderHit)) return;
            transform.Translate(translation);
        }
    }
}
