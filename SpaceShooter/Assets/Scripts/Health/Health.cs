using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] private int _maxHealth;
    [SerializeField] private Shader _shader;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    

    private int _health;
    private int _timesFlashed;
    private bool _isBlinking;
    private Material _material;
    private DeathHandler _deathHandler;

    private const int _NumPlayerFlash = 2;
    private const int _NumEnemyFlash = 1;

    private void Awake() {
        _health = _maxHealth;
        
        _timesFlashed = gameObject.CompareTag(GameTags.Player) ? _NumPlayerFlash : _NumEnemyFlash;

        _material = new Material(_shader);
        _material.mainTexture = _spriteRenderer.sprite.texture;
        _spriteRenderer.material = _material;

        _deathHandler = GetComponent<DeathHandler>();
    }

    public void OnDamage(int damage) {
        if (_isBlinking) return;

        FlashDamage();

        _health -= damage;
        Debug.Log("Health: " + gameObject.name + " " + _health);
        if(_health <= 0) {
            _deathHandler.HandleDeath(DeathHandler.DeathCause.Health0);
        }
    }

    public void OnHeal(int heal) {
        _health = Mathf.Min(_health + heal, _maxHealth);
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
