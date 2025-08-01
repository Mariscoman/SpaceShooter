using UnityEngine;

public static class BulletInstantiator {

    private static BulletConfiguration _config;

    static BulletInstantiator() {
        _config = Resources.Load<BulletConfiguration>("ScriptableObjects/BulletConfiguration");
    }

    public static void InstantiatePlayerBullet(Transform player) {
        Object.Instantiate(_config.PlayerBullet, player.position + Vector3.right * 0.1f, Quaternion.identity);
    }

    public static void InstantiateBomberBullet(Transform bomber) {
        Object.Instantiate(_config.BomberBullet, bomber.position + Vector3.left, Quaternion.identity);
    }
}
