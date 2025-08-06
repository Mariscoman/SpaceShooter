using UnityEngine;

public class DiagonalShootingMode : IShootingMode {
    public float Duration => 7f;

    private const float _Rotation = 25f;

    public void Shoot(Vector3 playerPosition, MonoBehaviour coroutineRunner) {
        PrefabInstantiator.InstantiatePlayerBullet(playerPosition);
        PrefabInstantiator.InstantiateRotatedPlayerBullet(playerPosition, _Rotation);
        PrefabInstantiator.InstantiateRotatedPlayerBullet(playerPosition, -_Rotation);
    }
}
