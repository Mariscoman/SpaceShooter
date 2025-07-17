using UnityEngine;

public class Health : MonoBehaviour {

    private int _Health;
    [SerializeField] private int _MaxHealth;

    private void Start() {
        _Health = _MaxHealth;
    }

    public void OnDamage(int damage) {
        _Health -= damage;
        if(_Health <= 0) {
            Destroy(gameObject);
        }
    }

    public void OnHeal(int heal) {
        _Health = Mathf.Min(_Health + heal, _MaxHealth);
    }
}
