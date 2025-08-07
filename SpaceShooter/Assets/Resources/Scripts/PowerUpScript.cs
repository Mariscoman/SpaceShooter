using UnityEngine;

public class PowerUpScript : MonoBehaviour {

    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;
    [SerializeField] private PowerUpType _type;
    [SerializeField] private Rigidbody2D _rb;

    private float _yAxisBound;
    private const float _Offset = 0.5f;

    private void ApplyPowerUp(PlayerShooting shootingSystem) { 
        switch(_type) {
            case PowerUpType.DoubleShooting:
                shootingSystem.SetDoubleShootingMode();
                break;
            case PowerUpType.RapidShooting:
                shootingSystem.SetRapidShootingMode();
                break;
            case PowerUpType.DiagonalShooting:
                shootingSystem.SetDiagonalShootingMode();
                break;
            default:
                shootingSystem.SetDefaultShootingMode();
                break;
        }
    }

    private void Start() {
        /* The power up moves to the left, I negate the speed here for inspector simplicity */
        _horizontalSpeed = -_horizontalSpeed;

        _rb.linearVelocity = new Vector2(_horizontalSpeed, _verticalSpeed);
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float spriteHeightOffset = GetComponent<SpriteRenderer>().bounds.size.y / 2 + _Offset;
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
            Destroy(gameObject);
        }
    }

    private enum PowerUpType {
        DoubleShooting,
        RapidShooting,
        DiagonalShooting
    }
}
