using UnityEngine;

[CreateAssetMenu(fileName = "ParticleConfiguration", menuName = "Scriptable Objects/ParticleConfiguration")]
public class ParticleConfiguration : ScriptableObject {
    [SerializeField] public ParticleSystem Explosion;
}
