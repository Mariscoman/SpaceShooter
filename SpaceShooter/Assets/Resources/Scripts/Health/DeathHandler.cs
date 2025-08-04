using UnityEngine;

public abstract class DeathHandler : MonoBehaviour {

    public void HandleDeath(DeathCause reason) {
        OnDie(reason);
        Destroy(gameObject);
    }

    protected abstract void OnDie(DeathCause reason);
    public enum DeathCause {
        Health0,
        LimitReached,
        LifeTimeFinished,
        Collision
    }
}
