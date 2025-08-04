using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class BomberDeathHandler : DeathHandler {

    private Dictionary<DeathCause, Action> _deathActions;

    private void Awake() {
        _deathActions = new Dictionary<DeathCause, Action>() {
            { DeathCause.Health0, SpawnPowerUp },
            { DeathCause.LimitReached, SpawnDamagingExplosion },
            { DeathCause.Collision, SpawnVisualExplosion }
        };
    }
    protected override void OnDie(DeathCause reason) {
        if (_deathActions.TryGetValue(reason, out var action)) {
            action();
        }
    }

    private void SpawnDamagingExplosion() {
        PrefabInstantiator.InstantiateDamagingExplosion(transform.position);
    }

    private void SpawnPowerUp() {
        SpawnVisualExplosion();
    }

    private void SpawnVisualExplosion() {
        PrefabInstantiator.InstantiateVisualExplosion(transform.position);
    }
}
