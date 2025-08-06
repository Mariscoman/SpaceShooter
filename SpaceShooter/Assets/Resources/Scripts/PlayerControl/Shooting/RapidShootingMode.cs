using System.Collections;
using UnityEngine;

public class RapidShootingMode : IShootingMode {
    public float Duration => 7f;

    private static readonly float _Delay = 0.1f;

    public void Shoot(Vector3 playerPosition, MonoBehaviour coroutineRunner) {
        PrefabInstantiator.InstantiatePlayerBullet(playerPosition);
        coroutineRunner.StartCoroutine(ShotDelay(playerPosition));
    }

    private IEnumerator ShotDelay(Vector3 playerPosition) {
        yield return new WaitForSeconds(_Delay);
        PrefabInstantiator.InstantiatePlayerBullet(playerPosition);
    }
}
