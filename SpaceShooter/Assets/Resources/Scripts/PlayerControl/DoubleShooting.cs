using UnityEngine;

public class DoubleShooting : IShootingMode {
    public float Duration => 10f;

    private static readonly Vector3 _VerticalOffset = new Vector3(0, 0.1f, 0);

    public void Shoot(Vector3 playerPosition, MonoBehaviour coroutineRunner) {
        PrefabInstantiator.InstantiatePlayerBullet(playerPosition + _VerticalOffset);
        PrefabInstantiator.InstantiatePlayerBullet(playerPosition - _VerticalOffset);
    }
}
