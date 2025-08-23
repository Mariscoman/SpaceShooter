using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour {
    [SerializeField] protected int _damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected Rigidbody2D _rb;

    protected abstract void Start();
    protected abstract void OnCollision(Collider2D collision);

    public void RotateBullet(float angle) {
        float angleRadians = angle * Mathf.Deg2Rad;
        float cos = Mathf.Cos(angleRadians);
        float sin = Mathf.Sin(angleRadians);

        _rb.linearVelocity = new Vector2(_rb.linearVelocityX * cos - _rb.linearVelocityY * sin,
                                        _rb.linearVelocityX * cos + _rb.linearVelocityY * sin);

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(GameTags.BulletDestructionWall)) { 
            Destroy(gameObject);
            return;
        }
        OnCollision(collision);
    }
}
