using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;  // Add this line for the Task class

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;

    public delegate void OnDie();
    public event OnDie onDie;

    [SerializeField] private HealthManager healthManager;

    public void OnEnable()
    {
        healthManager.onHealthChange += CheckIfDead;
    }

    public void OnDisable()
    {
        healthManager.onHealthChange -= CheckIfDead;
    }

    private async void CheckIfDead(float healthBetween0And1)
    {
        if (healthBetween0And1 <= 0)
        {
            GetComponent<Collider>().enabled = false;

            await Task.Delay(3000);

            onDie?.Invoke();
        }
    }

    void FixedUpdate()
    {
        var moveInput = move.action.ReadValue<Vector2>();
        rb.AddForce(speed * moveInput.y * transform.forward);
        var forwardVelocity = Vector3.Dot(rb.velocity, transform.forward);
        rb.AddTorque(forwardVelocity * moveInput.x * turnSpeed * transform.up);
    }
}
