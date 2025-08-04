using System;
using System.Collections.Generic;
using UnityEngine;

public class DroneDeathHandler : DeathHandler {

    private Dictionary<DeathCause, Action> _deathActions;

    private void Awake() {
        _deathActions = new Dictionary<DeathCause, Action>() {
            { DeathCause.Health0, SpawnMovingPowerUpAndVisualExplosion },
            { DeathCause.LifeTimeFinished, SpawnStaticPowerUpAndDamagingExplosion },
            { DeathCause.Collision, SpawnVisualExplosion }
        };
    }

    protected override void OnDie(DeathCause reason) {
        if (_deathActions.TryGetValue(reason, out var action)) {
            action();
        }
    }

    private void SpawnMovingPowerUpAndVisualExplosion() {
        SpawnVisualExplosion();
    }

    private void SpawnStaticPowerUpAndDamagingExplosion() {
        PrefabInstantiator.InstantiateDamagingExplosion(transform.position);
    }

    private void SpawnVisualExplosion() {
        PrefabInstantiator.InstantiateVisualExplosion(transform.position);
    }
}
