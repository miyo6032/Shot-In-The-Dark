using UnityEngine;

public class MovementInput : MonoBehaviour
{
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }

    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
    }
}