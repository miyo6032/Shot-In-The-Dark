using Game_Service;
using Game_Service.Services;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] private Vector2 movementBoundsMin;
    [SerializeField] private Vector2 movementBoundsMax;

    public float speed = 5;

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
        Vector3 movementVector = GetMovementDirection() * (speed * Time.fixedDeltaTime);
        var position = transform.position;
        var boundedPosX = Mathf.Clamp(movementVector.x + position.x, movementBoundsMin.x, movementBoundsMax.x);
        var boundedPosY = Mathf.Clamp(movementVector.y + position.y, movementBoundsMin.y, movementBoundsMax.y);
        var boundedMovement = new Vector2(boundedPosX, boundedPosY);
        position = boundedMovement;
        transform.position = position;
    }

    private Vector3 GetMovementDirection()
    {
        return new Vector3(playerInput.HorizontalInput, playerInput.VerticalInput, 0);
    }
}
