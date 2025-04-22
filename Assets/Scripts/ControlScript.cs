using UnityEngine;
using UnityEngine.InputSystem;

public class ControlScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D rb; //ref to a component
    private InputAction moveAction;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component attached to this GameObject
        moveAction = InputSystem.actions.FindAction("Move"); // Find the "Move" action in the Input System
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.AddForce(Vector2.up * 150f);
        //}
        rb.AddForce(5f * moveAction.ReadValue<Vector2>()); // Apply force to the Rigidbody2D based on the input value
    }
}
