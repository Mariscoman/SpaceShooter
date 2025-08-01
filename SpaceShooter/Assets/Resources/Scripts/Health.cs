using System.Collections;
using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class Health : MonoBehaviour {


    [SerializeField] private int _maxHealth;
    [SerializeField] private Shader _shader;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private int _health;
    private bool _isBlinking;
    private Material _material;

    private void Awake() {
        _health = _maxHealth;
        _material = new Material(_shader);
        _material.mainTexture = _spriteRenderer.sprite.texture;
        _spriteRenderer.material = _material;
    }

    public void OnDamage(int damage) {
        if (_isBlinking) return;

        FlashDamage();

        _health -= damage;
        if(_health <= 0) {
            Destroy(gameObject);
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
        for (int i = 0; i < 2; i++) {
            _material.SetFloat("_FlashAmount", 1f);
            yield return new WaitForSeconds(0.1f);
            _material.SetFloat("_FlashAmount", 0f);
            yield return new WaitForSeconds(0.1f);
        }
        _isBlinking = false;
    }
}
