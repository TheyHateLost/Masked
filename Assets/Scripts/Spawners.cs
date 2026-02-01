using UnityEngine;

public class Spawners : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private float _minimumSpawnTime;
    [SerializeField] private float _maximumSpawnTime;
    [SerializeField] private int _maxSpawns = 1;

    private float _timeUntilSpawn;
    private int _spawnCount = 0;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        if (_spawnCount >= _maxSpawns) return;
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            _spawnCount++;
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = _maximumSpawnTime;
    }

    // Fix for CS0246 and UNT0014: Remove usage of missing 'Enemy' type and treat as generic GameObject
    private void SpawnEnemy()
    {
        GameObject enemyGO = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        // Removed: Enemy enemyScript = enemyGO.GetComponent<Enemy>();
        // If you need to interact with a component on the enemy prefab, use GetComponent with the correct type
        // Example: var myComponent = enemyGO.GetComponent<MyComponentType>();
    }
    // it spawns but the enemies are being wack
    // i turned the max spawns code into // so it wouldnt be used as i didnt finsih in time
}