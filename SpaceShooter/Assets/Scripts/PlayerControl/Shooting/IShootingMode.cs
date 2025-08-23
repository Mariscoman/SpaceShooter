using UnityEngine;

public interface IShootingMode {

    public float Duration { get; }
    public void Shoot(Vector3 playerPosition, MonoBehaviour coroutineRunner);
}