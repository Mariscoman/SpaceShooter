using UnityEngine;

public class Health : MonoBehaviour {

    private int _Health;
    [SerializeField] private int _MaxHealth;

    public void OnDamage(int damage) {
        _Health -= damage;
        if(_Health <= 0) {
            Destroy(gameObject);
        }
    }

    public void OnHeal(int heal) {
        _Health += heal;
        _Health = Mathf.Min(_Health, _MaxHealth);
    }
}
