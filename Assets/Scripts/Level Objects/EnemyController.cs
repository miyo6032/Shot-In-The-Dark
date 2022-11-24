using System;
using Game_Service;
using Game_Service.Services;
using Pathing;
using UnityEngine;
using Util;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent( typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public NPatrolPath path;

        [SerializeField] private Animator animator;
        [SerializeField] private Transform visual;
        private static readonly int Speed = Animator.StringToHash("Speed");
        // public AudioClip ouch;

        private NMover mover;
        // internal AnimationController control;
        // internal Collider2D _collider;
        // internal AudioSource _audio;
        // SpriteRenderer spriteRenderer;

        // public Bounds Bounds => _collider.bounds;
        
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

        private void Update()
        {
            if (GameServiceProvider.GetService<IGameState>().GameState.Contains(GameState.TargetHit, GameState.BystanderHit)) return;
            mover ??= new NMover(path);
            visual.rotation = MathUtils.Get2DRotationFromDirection(mover.Direction);
            animator.SetFloat(Speed, mover.IsMoving ? 1 : 0);
        }

        void FixedUpdate()
        {
            if (GameServiceProvider.GetService<IGameState>().GameState.Contains(GameState.TargetHit, GameState.BystanderHit)) return;
            mover ??= new NMover(path);
            var transform1 = transform;
            transform1.position = mover.Position;
        }
    }
}