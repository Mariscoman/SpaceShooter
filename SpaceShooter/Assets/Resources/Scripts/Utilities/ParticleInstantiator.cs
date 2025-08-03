using UnityEngine;

public static class ParticleInstantiator {

    private static ParticleConfiguration _config;

    static ParticleInstantiator() {
        Resources.Load<ParticleConfiguration>("ScriptableObjects/ParticleConfiguration");
    }

    public static void InstantiateExplosionParticles(Vector3 location) {
        Object.Instantiate(_config.Explosion, location, Quaternion.identity);
    }
}
