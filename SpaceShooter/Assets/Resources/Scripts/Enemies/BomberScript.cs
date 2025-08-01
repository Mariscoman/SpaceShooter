using UnityEngine;

public class BomberScript : MonoBehaviour {
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private int _contactDamage;
    [SerializeField] private GameObject _bulletPrefab;

    private float _lastShot;
    private const float _ShootCooldown = 3f;

    private void Start() {
        _lastShot = Time.time;
        _rb.linearVelocityX = -_speed;
    }

    private void Update() {
        if (Time.time < _lastShot + _ShootCooldown) return;
        Shoot();
    }

    private void Shoot() {
        _lastShot = Time.time;
        BulletInstantiator.InstantiateBomberBullet(transform);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(_contactDamage);
        }
    }
}
