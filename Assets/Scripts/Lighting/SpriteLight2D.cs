using UnityEngine;

namespace Lighting
{
    public class SpriteLight2D : LevelLight
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private Animator empAnimator;
        private static readonly int Emp = Animator.StringToHash("Emp");

        public override void TurnOff()
        {
            sprite.color = Color.black;
            gameObject.SetActive(false);
            empAnimator.SetTrigger(Emp);
        }
    }
}