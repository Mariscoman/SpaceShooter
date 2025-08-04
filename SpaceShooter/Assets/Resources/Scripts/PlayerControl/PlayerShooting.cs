using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private float _Cooldown = 0.3f;

    private float _lastShot;
    private IShootingMode _currentShootingMode;

    private static readonly IShootingMode _DefaultShooting = new DefaultShooting();
    private static readonly IShootingMode _DoubleShooting = new DoubleShooting();
    private static readonly IShootingMode _RapidShooting = new RapidShooting();

    private void Awake() {
        _lastShot = 0;
        _currentShootingMode = _DefaultShooting;
    }

    public void OnShoot(InputAction.CallbackContext ctx) {
        if (Time.time < _lastShot + _Cooldown) return;
        _lastShot = Time.time;
        _currentShootingMode.Shoot(transform.position, this);
    }

    public void SetDefaultShootingMode() {
        _currentShootingMode = _DefaultShooting;
    }

    public void SetDoubleShootingMode() {
        StopAllCoroutines();
        _currentShootingMode = _DoubleShooting;
        StartCoroutine(PowerUpTimer(_DoubleShooting.Duration));
    }

    public void SetRapidShootingMode() {
        StopAllCoroutines();
        _currentShootingMode = _RapidShooting;
        StartCoroutine(PowerUpTimer(_RapidShooting.Duration));
    }

    private IEnumerator PowerUpTimer(float duration) {
        yield return new WaitForSeconds(duration);
        SetDefaultShootingMode();
    }
}
