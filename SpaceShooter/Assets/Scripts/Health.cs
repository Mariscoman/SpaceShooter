using UnityEngine;

public class Health : MonoBehaviour {


    [SerializeField] private int _maxHealth;

    private int _health;

    private void Start() {
        _health = _maxHealth;
    }

    public void OnDamage(int damage) {
        _health -= damage;
        if(_health <= 0) {
            Destroy(gameObject);
        }
    }

    public void OnHeal(int heal) {
        _health = Mathf.Min(_health + heal, _maxHealth);
    }
}
