using UnityEngine;
using UnityEngine.InputSystem;

public class ControlScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private InputAction moveAction;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        rb.AddForce(5f * moveAction.ReadValue<Vector2>());
    }
}
