using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour {
    private float _lastShot;
    private const float _Cooldown = 0.3f;
    public void OnShoot(InputAction.CallbackContext ctx) {
        if (Time.time < _lastShot + _Cooldown) return;
        _lastShot = Time.time;
        PrefabInstantiator.InstantiatePlayerBullet(transform.position);
    }
}
