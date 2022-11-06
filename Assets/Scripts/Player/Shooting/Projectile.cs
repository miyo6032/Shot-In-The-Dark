using Damage_System;
using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Player
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ImpactListener impactListener;
        
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
                GameServiceProvider.GetService<IGameState>().GameState = GameState.TargetHit;
                Destroy(gameObject);
            }
        }

        private void FixedUpdate()
        {
            transform.Translate(direction * Time.fixedDeltaTime, Space.World);
        }
    }
}