using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private MovementInput movementInput;
    [SerializeField] private Vector2 movementBoundsMin;
    [SerializeField] private Vector2 movementBoundsMax;

    public float speed = 5;

    void Start()
    {
        movementInput = GetComponent<MovementInput>();
    }

    void FixedUpdate()
    {
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
        return new Vector3(movementInput.HorizontalInput, movementInput.VerticalInput, 0);
    }
}
