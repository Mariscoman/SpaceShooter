using UnityEngine;

public abstract class DeathHandler : MonoBehaviour {

    public void HandleDeath(DeathCause reason) {
        OnDie(reason);
        Destroy(gameObject);
    }

    protected abstract void OnDie(DeathCause reason);

    protected void SpawnVisualExplosion() {
        PrefabInstantiator.InstantiateVisualExplosion(transform.position);
    }

    protected void SpawnDamagingExplosion() {
        PrefabInstantiator.InstantiateDamagingExplosion(transform.position);
    }

    public enum DeathCause {
        Health0,
        LimitReached,
        LifeTimeFinished,
        Collision
    }
}
