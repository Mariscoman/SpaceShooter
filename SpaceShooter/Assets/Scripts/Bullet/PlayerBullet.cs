using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerBullet : AbstractBullet {

    private static readonly Vector3 _DIRECTION = new Vector3(0, 0, 270);

    protected override void Start() {
        Rb.linearVelocity = Vector2.right * Speed;
        transform.Rotate(_DIRECTION);
    }

    protected override void OnCollision(Collider2D collision) {
        Transform other = collision.transform;
        if (!other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(Damage);
        }
        Destroy(gameObject);
    }
}
