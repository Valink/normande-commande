using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference attack;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardSpeed = 10;
    [SerializeField] private float backwardSpeed = 2;
    [SerializeField] private float turnSpeed = 5;

    void OnEnable()
    {
        attack.action.performed += ctx => Attack();
    }

    void OnDisable()
    {
        attack.action.performed -= ctx => Attack();
    }

    void FixedUpdate()
    {
        // TODO improve movement system
        var moveInput = move.action.ReadValue<Vector2>();
        rb.AddTorque(new Vector3(0, moveInput.x, 0) * turnSpeed);
        rb.AddForce(forwardSpeed * moveInput.y * transform.forward);
    }

    private void Attack()
    {
        // TODO
        Debug.Log("Attack");
    }
}
