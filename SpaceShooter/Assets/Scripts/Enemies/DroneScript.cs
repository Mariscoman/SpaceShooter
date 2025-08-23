using System.Collections;
using UnityEngine;

public class DroneScript : MonoBehaviour {

    
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _lifeTime;
    [SerializeField] private DeathHandler _deathHandler;

    private static Transform _Target;

    private const int _contactDamage = 5;

    private void Awake() {
        _Target ??= GameObject.FindGameObjectWithTag(GameTags.Player).transform;
    }
    private void Start() {
        StartCoroutine(DeathTimer());
    }

    private void FixedUpdate() {
        Vector2 direction = (Vector2)_Target.position - _rb.position;
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
            _deathHandler.HandleDeath(DeathHandler.DeathCause.Collision);
        }
    }

    private IEnumerator DeathTimer() {
        yield return new WaitForSeconds(_lifeTime);
        _deathHandler.HandleDeath(DeathHandler.DeathCause.LifeTimeFinished);
    }
}
