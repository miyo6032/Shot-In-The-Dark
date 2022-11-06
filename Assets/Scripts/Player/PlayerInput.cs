using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float VerticalInput { get; private set; }
    public float HorizontalInput { get; private set; }
    public bool EmpInput { get; private set; }

    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        EmpInput = Input.GetKeyDown(KeyCode.Space);
    }
}