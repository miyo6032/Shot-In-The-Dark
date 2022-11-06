using Pathing;
using UnityEngine;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent( typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        // public AudioClip ouch;

        private PatrolPath.Mover mover;
        // internal AnimationController control;
        // internal Collider2D _collider;
        // internal AudioSource _audio;
        // SpriteRenderer spriteRenderer;

        // public Bounds Bounds => _collider.bounds;
        
        public float maxSpeed = 7;

        void Awake()
        {
            // control = GetComponent<AnimationController>();
            // _collider = GetComponent<Collider2D>();
            // _audio = GetComponent<AudioSource>();
            // spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // var player = collision.gameObject.GetComponent<PlayerController>();
            // if (player != null)
            // {
            //     var ev = Schedule<PlayerEnemyCollision>();
            //     ev.player = player;
            //     ev.enemy = this;
            // }
        }

        void FixedUpdate()
        {
            mover ??= path.CreateMover(maxSpeed * 0.5f);
            transform.position = mover.Position;
        }
    }
}