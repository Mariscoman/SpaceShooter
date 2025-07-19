using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour {
    [SerializeField] protected int _damage;
    [SerializeField] protected float _speed;
    [SerializeField] protected Rigidbody2D _rb;

    protected abstract void Start();
    protected abstract void OnCollision(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag(GameTags.BulletDestructionWall)) { 
            Destroy(gameObject);
            return;
        }
        OnCollision(collision);
    }
}
