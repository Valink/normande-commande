using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public ParticleSystem particleSystem;
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
        var moveInput = move.action.ReadValue<Vector2>();
        rb.AddTorque(new Vector3(0, moveInput.x, 0) * turnSpeed);
        rb.AddForce(transform.forward * moveInput.y * forwardSpeed);
    }

    private void Attack()
    {
        Debug.Log("Attack");
    }
}
