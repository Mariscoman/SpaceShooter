using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class BomberScript : MonoBehaviour {
    [SerializeField] Rigidbody2D Rb;
    [SerializeField] float Speed;
    [SerializeField] GameObject bulletPrefab;

    private float _lastShot;
    private const float _ShootCooldown = 3f;
    private static readonly Vector3 _InitialRotation = new Vector3(0, 0, 90);

    private void Start() {
        _lastShot = Time.time;
        transform.Rotate(_InitialRotation);
        Rb.linearVelocityX = -Speed;
    }

    private void Update() {
        if (Time.time < _lastShot + _ShootCooldown) return;
        _lastShot = Time.time;
        Instantiate(bulletPrefab, transform.position + Vector3.left, Quaternion.identity);
    }
}
