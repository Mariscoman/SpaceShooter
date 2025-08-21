using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathHandler : DeathHandler {

    [SerializeField] private int _chanceOfPowerUpSpawn;
    [SerializeField] private bool _checksLimit;
    [SerializeField] private bool _hasLifeTime;

    protected override void OnDie(DeathCause reason) {
        switch (reason) {
            case DeathCause.Collision:
                SpawnPowerUpAndDamagingExplosion();
                break;
            case DeathCause.Health0:
                SpawnPowerUpAndVisualExplosion();
                break;
            case DeathCause.LimitReached:
                if(!_checksLimit) return;
                SpawnDamagingExplosion();
                break;
            case DeathCause.LifeTimeFinished:
                if(!_hasLifeTime) return;
                SpawnDamagingExplosion();
                break;
            default:
                break;
        }
    }

    private void SpawnPowerUpAndVisualExplosion() {
        SpawnPowerUp();
        SpawnVisualExplosion();
    }

    private void SpawnPowerUpAndDamagingExplosion() {
        SpawnPowerUp();
        SpawnDamagingExplosion();
    }

    private void SpawnPowerUp() {
        if (UnityEngine.Random.Range(0, _chanceOfPowerUpSpawn) == 0) return;
        PrefabInstantiator.InstantiateRandomPowerUp(transform.position);
    }
}
