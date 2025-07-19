using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "PlayerStats")]
public class PlayerStats : ScriptableObject {
    [Header("Level Configuration")]
    public int level{ get; private set;}
    public int requiredXP{ get; private set;}

    [Header("Combat Stats")]
    public int playerHealth{ get; private set;}
    public int playerHealing{ get; private set;}

    [Header("Movement Stats")]
    public float playerAcceleration{ get; private set;}
    public float playerDeceleration{ get; private set;}
    public float playerMaxSpeed{ get; private set;}

    [Header("Visual Components")]
    public GameObject bulletPrefab{ get; private set;}
    public Sprite playerSprite{ get; private set;}
}