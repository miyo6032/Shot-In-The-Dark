using Pathing;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent( typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public NPatrolPath path;
        // public AudioClip ouch;

        private NMover mover;
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
            mover ??= new NMover(path);
            transform.position = mover.Position;
        }
    }
}