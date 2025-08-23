using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "PrefabCollection", menuName = "Scriptable Objects/PrefabCollection")]
public class PrefabCollection : ScriptableObject {
    [Header("Bullets")]
    [SerializeField] public GameObject PlayerBullet;
    [SerializeField] public GameObject BomberBullet;

    [Header("Explosions")]
    [SerializeField] public GameObject DamagingExplosion;
    [SerializeField] public GameObject VisualExplosion;

    [Header("Power Ups")]
    [SerializeField] public GameObject[] PowerUps;

    [Header("Enemies")]
    [SerializeField] public GameObject BomberEnemy;
    [SerializeField] public GameObject DroneEnemy;
}
