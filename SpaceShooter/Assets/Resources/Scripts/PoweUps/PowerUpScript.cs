using UnityEngine;

public abstract class PowerUpScript : MonoBehaviour {

    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private Rigidbody2D _rb;

    private float _yAxisBound;
    private const float _Offset = 0.5f;

    protected abstract void ApplyPowerUp(PlayerShooting shootingSystem);

    private void Start() {
        /* The power up moves to the left, I negate the speed here for inspector simplicity */
        _horizontalSpeed = -_horizontalSpeed;

        _rb.linearVelocity = new Vector2(_horizontalSpeed, _verticalSpeed);
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float spriteHeightOffset = GetComponent<SpriteRenderer>().bounds.size.y / 2 - _Offset;
        _yAxisBound = screenBounds.y - spriteHeightOffset;
    }

    void FixedUpdate() {
        if ((transform.position.y <= -_yAxisBound) ||
            (transform.position.y >= _yAxisBound)) {
            _rb.linearVelocity = new Vector2(_horizontalSpeed, -_rb.linearVelocity.y);
            Debug.Log(_rb.linearVelocity);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Transform other = collision.transform;
        if(other.CompareTag(GameTags.Player)) {
            ApplyPowerUp(other.GetComponent<PlayerShooting>());
        }
        Destroy(gameObject);
    }
}
