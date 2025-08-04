using UnityEngine;

public class DefaultShooting : IShootingMode {
    public float Duration => 0f;

    public void Shoot(Vector3 playerPosition, MonoBehaviour coroutineRunner) {
        PrefabInstantiator.InstantiatePlayerBullet(playerPosition);
    }
}
