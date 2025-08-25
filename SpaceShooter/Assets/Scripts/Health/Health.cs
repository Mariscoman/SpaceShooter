using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] protected int _maxHealth;
    [SerializeField] private DeathHandler _deathHandler;
    [SerializeField] private Shader _shader;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    protected int _health;
    private int _timesFlashed;
    private float _lastTimeHit;

    private bool _isBlinking;

    private Material _material;

    private const int _NumPlayerFlash = 2;
    private const int _NumEnemyFlash = 1;
    private const float _MaxInvincibilityHitInterval = 0.05f;

    private void Awake() {
        _health = _maxHealth;
        
        _timesFlashed = gameObject.CompareTag(GameTags.Player) ? _NumPlayerFlash : _NumEnemyFlash;

        _material = new Material(_shader);
        _material.mainTexture = _spriteRenderer.sprite.texture;
        _spriteRenderer.material = _material;
    }

    public virtual void OnDamage(int damage) {
        if (!CanGetHit()) return;
        DoDamage(damage);
    }

    protected void DoDamage(int damage) {
        FlashDamage();
        _lastTimeHit = Time.time;
        _health -= damage;
        if (_health <= 0) {
            _deathHandler.HandleDeath(DeathHandler.DeathCause.Health0);
        }
    }

    public virtual void OnHeal(int heal) {
        if (!CanHeal()) return;
        DoHeal(heal);
    }
    protected void DoHeal(int heal) {
        _health = Mathf.Min(_health + heal, _maxHealth);
    }

    protected bool CanGetHit() {
        return !_isBlinking || Time.time - _lastTimeHit < _MaxInvincibilityHitInterval;
    }

    protected bool CanHeal() {
        return _maxHealth > _health;
    }

    private void FlashDamage() {
        StopAllCoroutines();
        StartCoroutine(FlashDamageRoutine());
    }

    private IEnumerator FlashDamageRoutine() {
        _isBlinking = true;
        for (int i = 0; i < _timesFlashed; i++) {
            _material.SetFloat("_FlashAmount", 1f);
            yield return new WaitForSeconds(0.1f);
            _material.SetFloat("_FlashAmount", 0f);
            yield return new WaitForSeconds(0.1f);
        }
        _isBlinking = false;
    }
}
