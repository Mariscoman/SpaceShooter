using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawnManager : MonoBehaviour {

    [SerializeField] private float _Cooldown;
    [SerializeField] private List<GameObject> _Formations;

    private float _LastSpawn;
    private float[] _MinMaxYPosition = { -4.4f, 4.4f };

    private void Start() {
        _LastSpawn = Time.time - _Cooldown + 1;
        Instantiate(_Formations[Random.Range(0, _Formations.Count)], new Vector3(3, -5, 0), Quaternion.identity);
    }

    private void Update() {
        if (Time.time < _LastSpawn + _Cooldown) return;
        _LastSpawn = Time.time;
        Vector3 position = new Vector3(3f, Random.Range(_MinMaxYPosition[0], _MinMaxYPosition[1]), 0);
        Instantiate(_Formations[Random.Range(0, _Formations.Count)], position, Quaternion.identity);
    }
}
