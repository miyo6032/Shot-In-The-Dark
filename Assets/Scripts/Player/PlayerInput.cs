using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }
    public bool EmpInput { get; private set; }

    void Update()
    {
        VerticalInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        EmpInput = Input.GetKeyDown(KeyCode.Space);
    }
}