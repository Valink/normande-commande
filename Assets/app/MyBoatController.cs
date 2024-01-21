using UnityEngine;
using UnityEngine.InputSystem;

public class MyBoatController : MonoBehaviour
{
  [SerializeField] private InputActionReference move;

  public PropellerBoats ship;
  bool forward = true;

  void Update()
  {
    var moveInput = move.action.ReadValue<Vector2>();
    var q = moveInput.x < 0;
    var d = moveInput.x > 0;
    var z = moveInput.y > 0;
    var s = moveInput.y < 0;

    if (q)
      ship.RudderLeft();
    if (d)
      ship.RudderRight();

    if (forward)
    {
      if (z)
        ship.ThrottleUp();
      else if (s)
      {
        ship.ThrottleDown();
        ship.Brake();
      }
    }
    else
    {
      if (s)
        ship.ThrottleUp();
      else if (z)
      {
        ship.ThrottleDown();
        ship.Brake();
      }
    }

    if (!z && !s)
      ship.ThrottleDown();

    if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.S) && forward)
    {
      forward = false;
      ship.Reverse();
    }
    else if (ship.engine_rpm == 0 && Input.GetKeyDown(KeyCode.Z) && !forward)
    {
      forward = true;
      ship.Reverse();
    }
  }
}
