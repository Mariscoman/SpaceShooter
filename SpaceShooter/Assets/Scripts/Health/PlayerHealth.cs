using UnityEngine;

public class PlayerHealth : Health {

    [SerializeField] private HealthBar _healthBar;

    public override void OnDamage(int damage) {
        if (!CanGetHit()) return;
        _healthBar.DrainHealthBar((float)(_health - damage) / _maxHealth);
        DoDamage(damage);
    }

    public override void OnHeal(int heal) {
        if (!CanHeal()) return;
        _healthBar.FillHealthBar((float)(_health + heal) / _maxHealth);
        base.OnHeal(heal);
    }
}
