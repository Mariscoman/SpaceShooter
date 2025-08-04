using UnityEngine;

[CreateAssetMenu(fileName = "PrefabCollection", menuName = "Scriptable Objects/PrefabCollection")]
public class PrefabCollection : ScriptableObject {
    [Header("Bullets")]
    [SerializeField] public GameObject PlayerBullet;
    [SerializeField] public GameObject BomberBullet;

    [Header("Explosions")]
    [SerializeField] public GameObject DamagingExplosion;
    [SerializeField] public GameObject VisualExplosion;
}
