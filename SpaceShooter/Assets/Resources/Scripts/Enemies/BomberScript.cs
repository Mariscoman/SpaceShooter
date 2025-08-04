using UnityEngine;

public class BomberScript : MonoBehaviour {
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private DeathHandler _deathHandler;

    private float _lastShot;
    private const float _ShootCooldown = 3f;
    private const int _contactDamage = 3;

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
        PrefabInstantiator.InstantiateBomberBullet(transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(_contactDamage);
            _deathHandler.HandleDeath(DeathHandler.DeathCause.Collision);
        }
        else if(other.CompareTag(GameTags.Wall)) {
            _deathHandler.HandleDeath(DeathHandler.DeathCause.LimitReached);
        }
    }
}
