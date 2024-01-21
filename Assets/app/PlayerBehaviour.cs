using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;  // Add this line for the Task class

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private InputActionReference move;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float forwardSpeed = 10;
    [SerializeField] private float turnSpeed = 5;

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
        // TODO improve movement system
        var moveInput = move.action.ReadValue<Vector2>();
        rb.AddTorque(new Vector3(0, moveInput.x, 0) * turnSpeed);
        rb.AddForce(forwardSpeed * moveInput.y * transform.forward);
    }
}
