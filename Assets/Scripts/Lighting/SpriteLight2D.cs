using System;
using UnityEngine;

namespace Lighting
{
    public class SpriteLight2D : LevelLight
    {
        [SerializeField] private SpriteRenderer sprite;
        [SerializeField] private SpriteRenderer offSprite;
        [SerializeField] private Animator empAnimator;
        private static readonly int Emp = Animator.StringToHash("Emp");

        private void Start()
        {
            offSprite.gameObject.SetActive(false);
        }

        public override void TurnOff()
        {
            sprite.gameObject.SetActive(false);
            offSprite.gameObject.SetActive(true);
            gameObject.SetActive(false);
            empAnimator.SetTrigger(Emp);
        }
    }
}