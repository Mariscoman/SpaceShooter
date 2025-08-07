using System;
using System.Collections.Generic;

public class DroneDeathHandler : DeathHandler {

    private Dictionary<DeathCause, Action> _deathActions;

    private void Awake() {
        _deathActions = new Dictionary<DeathCause, Action>() {
            { DeathCause.Health0, SpawnPowerUpAndVisualExplosion },
            { DeathCause.LifeTimeFinished, SpawnPowerUpAndDamagingExplosion },
            { DeathCause.Collision, SpawnVisualExplosion }
        };
    }

    protected override void OnDie(DeathCause reason) {
        if (_deathActions.TryGetValue(reason, out var action)) {
            action();
        }
    }

    private void SpawnPowerUpAndVisualExplosion() {
        SpawnPowerUp();
        SpawnVisualExplosion();
    }

    private void SpawnPowerUpAndDamagingExplosion() {
        SpawnPowerUp();
        SpawnVisualExplosion();
    }
}
