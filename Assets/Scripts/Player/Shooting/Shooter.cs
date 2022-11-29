using Game_Service;
using Game_Service.Services;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Util;
using Event = AK.Wwise.Event;

namespace Player.Shooting
{
    public class Shooter : MonoBehaviour
    {
        [SerializeField] float cooldown;
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private Transform visual;
        [SerializeField] private Animator animator;
        [SerializeField] private Slider slider;

        [SerializeField] private Event shootSoundEvent;
        // [SerializeField] private Transform cannonPivot;
        // [SerializeField] private AudioClip shootAudio;
        // [SerializeField] private AudioSource audioSource;
        private float currentCooldown;
        private static readonly int Shooting = Animator.StringToHash("Shooting");

        public void Update()
        {
            if (GameServiceProvider.GetService<IGamePauseService>().IsGamePaused) return;
            if (GameServiceProvider.GetService<IGameState>().GameState != GameState.IsDark) return;
            
            currentCooldown = Mathf.Max(currentCooldown - Time.deltaTime, 0);
            Vector2 direction2D = MathUtils.CalculateShootDirection2D(Input.mousePosition, transform.position);
            var rotationFromDirection = MathUtils.Get2DRotationFromDirection(direction2D);
            visual.rotation = rotationFromDirection;

            var cooldownRatio = currentCooldown / cooldown;
            slider.value = cooldownRatio;

            // cannonPivot.rotation = rotationFromDirection;

            var isOverGUI = EventSystem.current.IsPointerOverGameObject();
            if (currentCooldown == 0 && Input.GetButton("Fire1") && !isOverGUI)
            {
                Shoot(rotationFromDirection, direction2D);
            }
        }

        private void Shoot(Quaternion rotationFromDirection, Vector2 direction2D)
        {
            // audioSource.PlayOneShot(shootAudio);
            Projectile projectile = Instantiate(projectilePrefab, transform.position, rotationFromDirection);
            // audioSource.PlayOneShot(shootAudio);
            // bullet.Init(gameTimer, direction2D * bulletSpeed, 0, BulletStructure, bulletPrefab, audioSource);
            projectile.Init(direction2D * projectileSpeed);
            currentCooldown = cooldown;
            shootSoundEvent.Post(gameObject);
            animator.SetTrigger(Shooting);
        }
    }
}