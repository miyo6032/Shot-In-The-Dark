using Game_Service;
using Game_Service.Services;
using UnityEngine;
using Util;
using Event = AK.Wwise.Event;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector2 movementBoundsMin;
    [SerializeField] private Vector2 movementBoundsMax;
    [SerializeField] private Transform visual;
    [SerializeField] private Animator animator;
    [SerializeField] private Event movementSoundEvent;

    public float speed = 5;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private bool soundPlaying;
    private static readonly int Aiming = Animator.StringToHash("Aiming");

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        GameServiceProvider.GetService<IGameState>().AddGameStateChangeListener(StopMovement);
    }

    private void StopMovement(GameState obj)
    {
        if (obj == GameState.EmpActivated)
        {
            animator.SetFloat(Speed, 0);
            animator.SetBool(Aiming, true);
        }
    }

    void FixedUpdate()
    {
        if (GameServiceProvider.GetService<IGameState>().GameState == GameState.Setup)
            ApplyMovementInput();
    }

    private void ApplyMovementInput()
    {
        var movementDirection = GetMovementDirection();
        Vector3 movementVector = movementDirection.normalized * (speed * Time.fixedDeltaTime);
        var position = transform.position;
        var boundedPosX = Mathf.Clamp(movementVector.x + position.x, movementBoundsMin.x, movementBoundsMax.x);
        var boundedPosY = Mathf.Clamp(movementVector.y + position.y, movementBoundsMin.y, movementBoundsMax.y);
        var boundedMovement = new Vector2(boundedPosX, boundedPosY);
        position = boundedMovement;
        transform.position = position;

        PlayFootstepsSound(movementDirection);
        AnimateMovement(movementDirection);
    }

    private void PlayFootstepsSound(Vector3 movementDirection)
    {
        if (movementDirection.sqrMagnitude > 0.5f && !soundPlaying)
        {
            soundPlaying = true;
            movementSoundEvent.Post(gameObject, 1, (cookie, type, info) => soundPlaying = false);
        }
    }

    private void AnimateMovement(Vector3 movementDirection)
    {
        animator.SetFloat(Speed, movementDirection.sqrMagnitude);
        if (movementDirection.sqrMagnitude > 0.5f)
            visual.rotation = MathUtils.Get2DRotationFromDirection(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        return new Vector3(playerInput.HorizontalInput, playerInput.VerticalInput, 0);
    }
}
