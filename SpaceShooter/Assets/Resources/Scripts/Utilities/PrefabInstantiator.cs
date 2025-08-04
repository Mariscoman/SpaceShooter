using UnityEngine;

public static class PrefabInstantiator {

    private static PrefabCollection _prefabs;

    static PrefabInstantiator() {
        _prefabs = Resources.Load<PrefabCollection>("ScriptableObjects/PrefabCollection");
    }

    public static void InstantiatePlayerBullet(Vector3 playerPosition) {
        Object.Instantiate(_prefabs.PlayerBullet, playerPosition + Vector3.right * 0.1f, Quaternion.identity);
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
}
