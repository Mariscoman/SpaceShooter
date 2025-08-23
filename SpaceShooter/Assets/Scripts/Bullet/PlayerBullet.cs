using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerBullet : AbstractBullet {

    private static readonly Vector3 Direction = new Vector3(0, 0, 270);

    protected override void Start() {
        _rb.linearVelocity = transform.rotation * Vector2.right * _speed;
        transform.Rotate(Direction);
    }

    protected override void OnCollision(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Enemy)) {
            other.GetComponent<Health>().OnDamage(_damage);
            Destroy(gameObject);
        }
    }
}
