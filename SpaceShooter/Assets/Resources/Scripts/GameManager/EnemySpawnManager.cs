using System.Collections.Generic;
using Unity.Mathematics.Random;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    [SerializeField] private bool SPAWN;
    [SerializeField] private float _cooldown;
    [SerializeField] private 

    private float _yBomberBound;
    private float _yDroneBound;

    private void Start() {
        if (!SPAWN) return;
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        PrefabCollection prefabs = Resources.Load<PrefabCollection>("ScriptableObjects/PrefabCollection");

        float spriteHeightOffset = prefabs.BomberEnemy.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        _yBomberBound = screenBounds.y - spriteHeightOffset;

        spriteHeightOffset = prefabs.DroneEnemy.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        _yDroneBound = screenBounds.y - spriteHeightOffset;
    }

    private void Update() {
        if (!SPAWN) return;
    }

    private void Spawn3BomberFormation() {
        
    }
    private void Spawn3SeparateBomberFormation() {

    }
    private void SpawnBomber() {

    }
    private void Spawn2SeparateDrones() {

    }
    private void SpawnDrone() {

    }
}
