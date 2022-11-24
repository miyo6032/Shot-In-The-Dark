using System;
using Damage_System;
using Game_Service;
using Game_Service.Front_End_Services;
using UnityEngine;

namespace Level_Objects
{
    public class Bystander : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;
        [SerializeField] private ImpactListener impactListener;
        private static readonly int Hit = Animator.StringToHash("Hit");

        private void Start()
        {
            FrontEndServiceProvider.GetService<ILightingService>().RegisterSpriteToHide(spriteRenderer);
            impactListener.AddImpactListener(TargetHit);
        }

        private void TargetHit(Collider2D obj)
        {
            if (obj.CompareTag("Projectile"))
            {
                animator.SetTrigger(Hit);
            }
        }
    }
}