using Damage_System;
using Game_Service;
using Game_Service.Front_End_Services;
using Game_Service.Services;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Player
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ImpactListener impactListener;
        [SerializeField] private Light2D projectileLight;
        
        private Vector2 direction;

        public void Init(Vector2 dir)
        {
            direction = dir;
            impactListener.AddImpactListener(TargetHit);
        }

        private void TargetHit(Collider2D obj)
        {
            if (obj.CompareTag("Target"))
            {
                Debug.Log("Target Hit!");
                Time.timeScale = 0.2f;
                ShowTargets();
                GameServiceProvider.GetService<IGameState>().GameState = GameState.TargetHit;
            }
            else if (obj.CompareTag("Bystander"))
            {
                Time.timeScale = 0.2f;
                ShowTargets();
                Debug.Log("Bystander Hit!");
            }
            else if (obj.CompareTag("Obstacle"))
            {
                Debug.Log("Obstacle Hit!");
            }
            Destroy(gameObject);
        }

        private void ShowTargets()
        {
            var position = transform.position;
            Instantiate(projectileLight, position, Quaternion.identity);
            FrontEndServiceProvider.GetService<ILightingService>().ShowSpritesInRadius(position, projectileLight.pointLightOuterRadius + 0.5f);
        }

        private void FixedUpdate()
        {
            transform.Translate(direction * Time.fixedDeltaTime, Space.World);
        }
    }
}