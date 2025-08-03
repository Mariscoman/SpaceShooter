using UnityEngine;

public static class BulletInstantiator {

    private static BulletConfiguration _config;

    static BulletInstantiator() {
        _config = Resources.Load<BulletConfiguration>("ScriptableObjects/BulletConfiguration");
    }

    public static void InstantiatePlayerBullet(Vector3 playerPosition) {
        Object.Instantiate(_config.PlayerBullet, playerPosition + Vector3.right * 0.1f, Quaternion.identity);
    }

    public static void InstantiateBomberBullet(Vector3 bomberPosition) {
        Object.Instantiate(_config.BomberBullet, bomberPosition + Vector3.left, Quaternion.identity);
    }
}
