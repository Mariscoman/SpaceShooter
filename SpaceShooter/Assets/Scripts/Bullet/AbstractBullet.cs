using UnityEngine;

public abstract class AbstractBullet : MonoBehaviour {
    [SerializeField] protected int Damage;
    [SerializeField] protected float Speed;
    [SerializeField] protected Rigidbody2D Rb;

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
