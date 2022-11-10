using Game_Service;
using Game_Service.Services;
using UnityEngine;
using Util;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector2 movementBoundsMin;
    [SerializeField] private Vector2 movementBoundsMax;
    [SerializeField] private Transform visual;
    [SerializeField] private Animator animator;

    public float speed = 5;
    private static readonly int Speed = Animator.StringToHash("Speed");

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
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
        
        AnimateMovement(movementDirection);
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
