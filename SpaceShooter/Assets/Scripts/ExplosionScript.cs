using System.Collections;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
    
    [SerializeField] private ParticleSystem _particleSystem;
    private const int _ExplosionDamage = 5;

    private void Start() {
        _particleSystem.Play();
        StartCoroutine(Dissapear());
    }

    private IEnumerator Dissapear() {
        yield return new WaitWhile(() => _particleSystem.isPlaying);
        Destroy(gameObject);
    }

    /* This method is only called in explosions with a rigid body and a collider */
    private void OnTriggerEnter2D(Collider2D collision) {
        Transform other = collision.transform;
        if (other.CompareTag(GameTags.Player)) {
            other.GetComponent<Health>().OnDamage(_ExplosionDamage);
        }
    }
}
