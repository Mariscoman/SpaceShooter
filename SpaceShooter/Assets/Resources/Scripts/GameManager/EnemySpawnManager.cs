using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    [SerializeField] private bool SPAWN;
    [SerializeField] private float _cooldown;
    [SerializeField] private List<GameObject> _formations;

    private float _lastSpawn;
    private float[] _minMaxYPosition = { -4.4f, 4.4f };

    private void Start() {
        _lastSpawn = Time.time - _cooldown + 1;
        Instantiate(_formations[Random.Range(0, _formations.Count)], new Vector3(3, -5, 0), Quaternion.identity);
    }

    private void Update() {
        if (!SPAWN) return;
        if (Time.time < _lastSpawn + _cooldown) return;
        _lastSpawn = Time.time;
        Vector3 position = new Vector3(3f, Random.Range(_minMaxYPosition[0], _minMaxYPosition[1]), 0);
        Instantiate(_formations[Random.Range(0, _formations.Count)], position, Quaternion.identity);
    }
}
