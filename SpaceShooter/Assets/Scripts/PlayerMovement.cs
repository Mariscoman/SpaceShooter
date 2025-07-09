using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rg;
    private float _vertical;
    private float _movementAcceleration = 35f;
    private static readonly float _MAX_SPEED = 7f;

    private void Start() {
        /* This makes the player decelerate when not pressing any movement keys */
        rg.linearDamping = 2.0f;
    }

    private void FixedUpdate() {
        /* Accelerates the player on the Y axis acording to their input */
        rg.AddForceY(_vertical* _movementAcceleration);
        /* Locks the acceleration when the max speed is reached */
        if (rg.linearVelocityY >= _MAX_SPEED) rg.linearVelocityY = _MAX_SPEED;
        if (rg.linearVelocityY <= -_MAX_SPEED) rg.linearVelocityY = -_MAX_SPEED;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        _vertical = ctx.ReadValue<float>();
    }
}
