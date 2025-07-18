using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] GameObject bulletPrefab;

    private float _lastShot;
    private const float _COOLDOWN = 0.3f;
    public void OnShoot(InputAction.CallbackContext ctx) {
        if (Time.time < _lastShot + _COOLDOWN) return;
        _lastShot = Time.time;
        Instantiate(bulletPrefab, transform.position + Vector3.right * 0.1f, Quaternion.identity);
    }
}
