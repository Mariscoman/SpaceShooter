using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private Rigidbody2D _rb;

    private float _vertical;
    private const float _MovementAcceleration = 35f;
    private const float _MaxSpeed = 7f;

    private float _yAxisBound;
    private const float _Offset = 0.2f;

    private void Start() {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float spriteHeightOffset = GetComponent<SpriteRenderer>().bounds.size.y/2 + _Offset;

        _yAxisBound = screenBounds.y - spriteHeightOffset;
    }

    private void FixedUpdate() {
        /* Blocks the player from going offscreen */
        if ((transform.position.y <= -_yAxisBound && _vertical != 1) ||
            (transform.position.y >= _yAxisBound && _vertical != -1)) {

            _rb.linearVelocity = Vector2.zero;
            return;
        }

        /* Accelerates the player on the Y axis acording to their input */
        _rb.AddForceY(_vertical* _MovementAcceleration);
        /* Locks the acceleration when the max speed is reached */
        if (_rb.linearVelocityY >= _MaxSpeed) _rb.linearVelocityY = _MaxSpeed;
        if (_rb.linearVelocityY <= -_MaxSpeed) _rb.linearVelocityY = -_MaxSpeed;
    }

    public void OnMove(InputAction.CallbackContext ctx) {
        _vertical = ctx.ReadValue<float>();
    }
}
