using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] Rigidbody2D Rb;

    private float _Vertical;
    private const float _MovementAcceleration = 35f;
    private const float _MaxSpeed = 7f;

    private float _YAxisBound;
    private const float _Offset = 0.2f;

    private void Start() {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float spriteHeightOffset = GetComponent<SpriteRenderer>().bounds.size.y/2 + _Offset;

        _YAxisBound = screenBounds.y - spriteHeightOffset;
    }

    private void FixedUpdate() {
        /* Blocks the player from going offscreen */
        if ((transform.position.y <= -_YAxisBound && _Vertical != 1) ||
            (transform.position.y >= _YAxisBound && _Vertical != -1)) {

            Rb.linearVelocity = Vector2.zero;
            return;
        }

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
