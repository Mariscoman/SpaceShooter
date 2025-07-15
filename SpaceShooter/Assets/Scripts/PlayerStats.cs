using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject {
    [Header("Level Configuration")]
    public int Level{ get; private set;}
    public int RequiredXP{ get; private set;}

    [Header("Combat Stats")]
    public int PlayerHealth{ get; private set;}
    public int PlayerHealing{ get; private set;}

    [Header("Movement Stats")]
    public float PlayerAcceleration{ get; private set;}
    public float PlayerDeceleration{ get; private set;}
    public float PlayerMaxSpeed{ get; private set;}

    [Header("Visual Components")]
    public GameObject BulletPrefab{ get; private set;}
    public Sprite PlayerSprite{ get; private set;}
}