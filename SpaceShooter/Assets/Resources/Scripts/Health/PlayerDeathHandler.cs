using UnityEngine;

public class PlayerDeathHandler : DeathHandler {

    protected override void OnDie(DeathCause reason) {
        PrefabInstantiator.InstantiateVisualExplosion(transform.position);
        Time.timeScale = 0f;
        Debug.Log("PlayerDeath.OnDie: Fin del juego");
    }
}
