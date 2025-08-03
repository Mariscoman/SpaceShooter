using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfiguration", menuName = "Scriptable Objects/BulletConfiguration")]
public class BulletConfiguration : ScriptableObject {
    [SerializeField] public GameObject PlayerBullet;
    [SerializeField] public GameObject BomberBullet;
}
