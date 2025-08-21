using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static PowerUpScript;

public class PlayerShooting : MonoBehaviour {

    [SerializeField] private float _Cooldown = 0.3f;

    private float _lastShot;
    private IShootingMode _currentShootingMode;

    private static readonly IShootingMode _DefaultShooting = new DefaultShootingMode();
    private static readonly IShootingMode _DoubleShooting = new DoubleShootingMode();
    private static readonly IShootingMode _RapidShooting = new RapidShootingMode();
    private static readonly IShootingMode _DiagonalShooting = new DiagonalShootingMode();

    private void Awake() {
        _lastShot = 0;
        _currentShootingMode = _DefaultShooting;
    }

    public void OnShoot(InputAction.CallbackContext ctx) {
        if (Time.time < _lastShot + _Cooldown) return;
        _lastShot = Time.time;
        _currentShootingMode.Shoot(transform.position, this);
    }

    public void OnPowerUp(PowerUpScript.PowerUpType powerUp) {
        switch (powerUp) {
            case PowerUpType.DoubleShooting:
                SetDoubleShootingMode();
                break;
            case PowerUpType.RapidShooting:
                SetRapidShootingMode();
                break;
            case PowerUpType.DiagonalShooting:
                SetDiagonalShootingMode();
                break;
            default:
                SetDefaultShootingMode();
                break;
        }
    }

    private void SetDefaultShootingMode() {
        _currentShootingMode = _DefaultShooting;
    }

    private void SetDoubleShootingMode() {
        StopAllCoroutines();
        _currentShootingMode = _DoubleShooting;
        StartCoroutine(PowerUpTimer(_DoubleShooting.Duration));
    }

    private void SetRapidShootingMode() {
        StopAllCoroutines();
        _currentShootingMode = _RapidShooting;
        StartCoroutine(PowerUpTimer(_RapidShooting.Duration));
    }

    private void SetDiagonalShootingMode() {
        StopAllCoroutines();
        _currentShootingMode = _DiagonalShooting;
        StartCoroutine(PowerUpTimer(_DiagonalShooting.Duration));
    }

    private IEnumerator PowerUpTimer(float duration) {
        yield return new WaitForSeconds(duration);
        SetDefaultShootingMode();
    }
}
