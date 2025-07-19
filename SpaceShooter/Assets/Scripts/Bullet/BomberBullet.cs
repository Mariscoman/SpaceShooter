using UnityEngine;

public class BomberBullet : AbstractBullet {

    private static readonly Vector3 Direction = new Vector3(0, 0, 90);

    protected override void Start() {
        _rb.linearVelocity = Vector3.left * _speed;
        transform.Rotate(Direction);
    }

    protected override void OnCollision(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(_damage);
            Destroy(gameObject);
        }
    }
}
