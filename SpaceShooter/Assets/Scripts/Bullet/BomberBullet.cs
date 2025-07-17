using UnityEngine;

public class BomberBullet : AbstractBullet {

    private static Vector3 _Direction = new Vector3(0, 0, 90);

    protected override void Start() {
        Rb.linearVelocity = Vector3.left * Speed;
        transform.Rotate(_Direction);
    }

    protected override void OnCollision(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(Damage);
            Destroy(gameObject);
        }
    }
}
