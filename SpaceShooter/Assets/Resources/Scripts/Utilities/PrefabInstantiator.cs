using UnityEngine;
using UnityEngine.UIElements;

public static class PrefabInstantiator {

    private static PrefabCollection _prefabs;

    private static readonly Vector3 _PlayerHorizontalBulletSpawnOffset = Vector3.right * 0.1f;
    private static readonly Vector3 _PlayerVerticalBulletSpawnOffset = Vector3.up * 0.2f;

    static PrefabInstantiator() {
        _prefabs = Resources.Load<PrefabCollection>("ScriptableObjects/PrefabCollection");
    }

    public static void InstantiatePlayerBullet(Vector3 playerPosition) {
        Object.Instantiate(_prefabs.PlayerBullet, playerPosition + _PlayerHorizontalBulletSpawnOffset, Quaternion.identity);
    }
    public static void InstantiateRotatedPlayerBullet(Vector3 playerPosition, float rotationAngle) {
        /* Diagonal bullets will appear slighty above o below the normal spawn position */
        Vector3 spawnOffset = _PlayerHorizontalBulletSpawnOffset;
        if (rotationAngle >= 0 && rotationAngle < 180) spawnOffset += _PlayerVerticalBulletSpawnOffset;
        else spawnOffset -= _PlayerVerticalBulletSpawnOffset;

        /* Instance and rotate de bullet */
        GameObject instance = Object.Instantiate(_prefabs.PlayerBullet, playerPosition + spawnOffset, Quaternion.identity);
        instance.GetComponent<AbstractBullet>().RotateBullet(rotationAngle);
    }
    public static void InstantiateBomberBullet(Vector3 bomberPosition) {
        Object.Instantiate(_prefabs.BomberBullet, bomberPosition + Vector3.left, Quaternion.identity);
    }


    public static void InstantiateDamagingExplosion(Vector3 position) {
        Object.Instantiate(_prefabs.DamagingExplosion, position, Quaternion.identity);
    }
    public static void InstantiateVisualExplosion(Vector3 position) {
        Object.Instantiate(_prefabs.VisualExplosion, position, Quaternion.identity);
    }
    public static void InstantiateRandomPowerUp(Vector3 position) {
        Object.Instantiate(_prefabs.PowerUps[Random.Range(0, _prefabs.PowerUps.Length)], position, Quaternion.identity);
    }

    
    public static void InstantiateBomberEnemy(Vector3 position) {
        Object.Instantiate(_prefabs.BomberEnemy, position, Quaternion.Euler(0, 0, 90));
    }
    public static void InstantiateDroneEnemy(Vector3 position) {
        Object.Instantiate(_prefabs.DroneEnemy, position, Quaternion.Euler(0, 0, 90));
    }
}
