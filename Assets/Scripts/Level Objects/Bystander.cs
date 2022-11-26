using System;
using Damage_System;
using Game_Service;
using Game_Service.Front_End_Services;
using UnityEngine;

namespace Level_Objects
{
    public class Bystander : HideableVisual
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] SpriteRenderer shirtRenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private ImpactListener impactListener;
        private static readonly int Hit = Animator.StringToHash("Hit");

        private void Start()
        {
            FrontEndServiceProvider.GetService<ILightingService>().RegisterSpriteToHide(this);
            impactListener.AddImpactListener(TargetHit);
        }

        private void TargetHit(Collider2D obj)
        {
            if (obj.CompareTag("Projectile"))
            {
                animator.SetTrigger(Hit);
            }
        }

        public override void Hide(float alpha)
        {
            LightingHandler.SetReducedAlpha(spriteRenderer, alpha);
            LightingHandler.SetReducedAlpha(shirtRenderer, alpha);
        }

        public override void Show()
        {
            LightingHandler.RestoreAlpha(spriteRenderer);
            LightingHandler.RestoreAlpha(shirtRenderer);
        }
    }
}