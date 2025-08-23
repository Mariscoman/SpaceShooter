using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    [SerializeField] private float _cooldown;

    private float _lastSpawn;
    private Vector3[] _spawnPositions;

    private const int _NumSpawnPositions = 10;
    private const float _XSpawnPosition = 10f;
    private const int _NumSpawnFormations = 3;

    private void Start() {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float spawnSpace = (screenBounds.y - GameManager.CameraBorderOffset) * 2;
        float spawnSeparation = spawnSpace / (_NumSpawnPositions - 1);

        float upperSpawnPosition = (screenBounds.y - GameManager.CameraBorderOffset);
        _spawnPositions = new Vector3[_NumSpawnPositions];
        for (int i = 0; i < _spawnPositions.Length; i++) {
            _spawnPositions[i] = new Vector3(_XSpawnPosition, upperSpawnPosition - spawnSeparation * i, 0);
        }
    }

    private void Update() {
        if (_lastSpawn + _cooldown < Time.time) {
            _lastSpawn = Time.time;
            int formation = Random.Range(0, _NumSpawnFormations);
            switch(formation) {
                case 0:
                    Spawn3BombersFormation();
                    break;
                case 1:
                    Spawn3SeparateBombers();
                    break;
                case 2:
                    Spawn2SeparateDrones();
                    break;
            }
        }
    }

    private (Vector3, int) GetRandomSpawnPosition(int upperSpawnPositionBound = 0, int lowerSpawnPositionBound = _NumSpawnPositions) {
        int position = Random.Range(upperSpawnPositionBound, lowerSpawnPositionBound);
        return (_spawnPositions[position], position);
    }

    private void Spawn3BombersFormation() {
        var (position, centralIndex) = GetRandomSpawnPosition();
        PrefabInstantiator.InstantiateBomberEnemy(position);

        if (centralIndex == 0) {
            PrefabInstantiator.InstantiateBomberEnemy(_spawnPositions[centralIndex + 1]);
            PrefabInstantiator.InstantiateBomberEnemy(_spawnPositions[centralIndex + 2]);
        } else if(centralIndex == _NumSpawnPositions - 1) {
            PrefabInstantiator.InstantiateBomberEnemy(_spawnPositions[centralIndex - 1]);
            PrefabInstantiator.InstantiateBomberEnemy(_spawnPositions[centralIndex - 2]);
        } else {
            PrefabInstantiator.InstantiateBomberEnemy(_spawnPositions[centralIndex + 1]);
            PrefabInstantiator.InstantiateBomberEnemy(_spawnPositions[centralIndex - 1]);
        }
    }
    private void Spawn3SeparateBombers() {
        var (position, index) = GetRandomSpawnPosition();
        while (index == 0 || index == _NumSpawnPositions - 1) {
            (position, index) = GetRandomSpawnPosition();
        }
        PrefabInstantiator.InstantiateBomberEnemy(position);
        (position, index) = GetRandomSpawnPosition(upperSpawnPositionBound: index);
        PrefabInstantiator.InstantiateBomberEnemy(position);
        (position, index) = GetRandomSpawnPosition(lowerSpawnPositionBound: index);
        PrefabInstantiator.InstantiateBomberEnemy(position);
    }
    private void Spawn2SeparateDrones() {
        var (firstPosition, firstIndex) = GetRandomSpawnPosition(lowerSpawnPositionBound: _NumSpawnPositions / 3);
        PrefabInstantiator.InstantiateDroneEnemy(firstPosition);

        var (secondPosition, secondIndex) = GetRandomSpawnPosition(upperSpawnPositionBound: 2 * (_NumSpawnPositions / 3));
        PrefabInstantiator.InstantiateDroneEnemy(secondPosition);
    }
}
