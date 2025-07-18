using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BomberScript : MonoBehaviour {
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] float Speed;
    [SerializeField] int ContactDamage;
    [SerializeField] GameObject bulletPrefab;

    private float _lastShot;
    private const float _ShootCooldown = 3f;

    private void Start() {
        _lastShot = Time.time;
        Rb.linearVelocityX = -Speed;
    }

    private void Update() {
        if (Time.time < _lastShot + _ShootCooldown) return;
        Shoot();
    }

    private void Shoot() {
        _lastShot = Time.time;
        Instantiate(bulletPrefab, transform.position + Vector3.left, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(ContactDamage);
        }
    }
}
