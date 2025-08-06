using UnityEngine;

public class DefaultShootingMode : IShootingMode {
    public float Duration => 0f;

    public void Shoot(Vector3 playerPosition, MonoBehaviour coroutineRunner) {
        PrefabInstantiator.InstantiateRotatedPlayerBullet(playerPosition, 30);
    }
}
