using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    void FixedUpdate()
    {
        var moveInput = move.action.ReadValue<Vector2>();
        rb.AddForce(speed * moveInput.y * transform.forward);
        var forwardVelocity = Vector3.Dot(rb.velocity, transform.forward);
        rb.AddTorque(forwardVelocity * moveInput.x * turnSpeed * transform.up);
    }
}
