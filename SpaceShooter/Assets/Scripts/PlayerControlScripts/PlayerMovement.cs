using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] Rigidbody2D Rb;
    private float _Vertical;
    private const float _MovementAcceleration = 35f;
    private const float _MaxSpeed = 7f;

    private void Start() {
        /* This makes the player decelerate when not pressing any movement keys */
        Rb.linearDamping = 2.0f;
    }

    private void FixedUpdate() {
        /* Accelerates the player on the Y axis acording to their input */
        Rb.AddForceY(_Vertical* _MovementAcceleration);
        /* Locks the acceleration when the max speed is reached */
        if (Rb.linearVelocityY >= _MaxSpeed) Rb.linearVelocityY = _MaxSpeed;
        if (Rb.linearVelocityY <= -_MaxSpeed) Rb.linearVelocityY = -_MaxSpeed;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        _Vertical = ctx.ReadValue<float>();
    }
}
