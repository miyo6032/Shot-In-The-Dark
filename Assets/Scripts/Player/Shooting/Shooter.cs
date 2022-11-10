using Game_Service;
using Game_Service.Services;
using UnityEngine;

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
            Vector2 direction2D = CalculateShootDirection2D(Input.mousePosition);
            var rotationFromDirection = Get2DRotationFromDirection(direction2D);

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

        private Vector2 CalculateShootDirection2D(Vector3 mousePos)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldMousePos2d = worldMousePos;
            Vector2 pos2d = transform.position;
            return (worldMousePos2d - pos2d).normalized;
        }

        private static Quaternion Get2DRotationFromDirection(Vector3 dir)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}