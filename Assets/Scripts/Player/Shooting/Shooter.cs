using Game_Service;
using Game_Service.Services;
using UnityEngine;
using Util;

namespace Player.Shooting
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] float cooldown;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float projectileSpeed;
        // [SerializeField] private Transform cannonPivot;
        // [SerializeField] private AudioClip shootAudio;
        // [SerializeField] private AudioSource audioSource;
        private float currentCooldown;

        public void Update()
        {
            if (GameServiceProvider.GetService<IGameState>().GameState != GameState.IsDark) return;
            
            currentCooldown = Mathf.Max(currentCooldown - Time.deltaTime, 0);
            Vector2 direction2D = MathUtils.CalculateShootDirection2D(Input.mousePosition, transform.position);
            var rotationFromDirection = MathUtils.Get2DRotationFromDirection(direction2D);

            // cannonPivot.rotation = rotationFromDirection;

            if (currentCooldown == 0 && Input.GetMouseButton(0))
            {
                GameServiceProvider.GetService<IGameTimer>().StopTimer();
                // audioSource.PlayOneShot(shootAudio);
                Projectile projectile = Instantiate(projectilePrefab, transform.position, rotationFromDirection);
                // audioSource.PlayOneShot(shootAudio);
                // bullet.Init(gameTimer, direction2D * bulletSpeed, 0, BulletStructure, bulletPrefab, audioSource);
                projectile.Init(direction2D * projectileSpeed);
                currentCooldown = cooldown;
            }
        }
    }
}