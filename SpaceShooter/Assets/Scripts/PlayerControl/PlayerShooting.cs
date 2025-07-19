using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private GameObject _bulletPrefab;

    private float _lastShot;
    private const float _Cooldown = 0.3f;
    public void OnShoot(InputAction.CallbackContext ctx) {
        if (Time.time < _lastShot + _Cooldown) return;
        _lastShot = Time.time;
        Instantiate(_bulletPrefab, transform.position + Vector3.right * 0.1f, Quaternion.identity);
    }
}
