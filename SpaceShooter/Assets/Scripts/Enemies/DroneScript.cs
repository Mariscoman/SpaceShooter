using UnityEngine;

public class DroneScript : MonoBehaviour {

    [SerializeField] private Transform _target;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _maxHomingTimer;

    private int _contactDamage = 5;
    private float _timerStart;

    private void Start() {
        _timerStart = Time.time;
    }

    private void FixedUpdate() {
        if (_maxHomingTimer <= Time.time - _timerStart) return;

        Vector2 direction = (Vector2)_target.position - _rb.position;
        direction.Normalize();

        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        float currentAngle = transform.eulerAngles.z;
        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, _rotateSpeed * Time.fixedDeltaTime);
        transform.rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);

        Vector2 forwardDirection = transform.up;
        _rb.linearVelocity = forwardDirection * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(_contactDamage);
            Destroy(gameObject);
        }
    }
}
