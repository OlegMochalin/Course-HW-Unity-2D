using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyTarget))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private int _enemiesAmount = 10;
    [SerializeField] private float _spawnDelay = 2;

    private EnemyTarget _enemyTarget;
    private EnemySpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _enemyTarget = GetComponent<EnemyTarget>();
        _spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForSeconds = new WaitForSeconds(_spawnDelay);
        int startSpawnPoint = 0;

        for (int i = 0; i < _enemiesAmount; i++)
        {
            Enemy enemy = Instantiate(_enemyPrefabs[0], _spawnPoints[startSpawnPoint].transform.position, transform.rotation);
            enemy.GetTarget(_enemyTarget);

            if (startSpawnPoint < _spawnPoints.Length)
            {
                startSpawnPoint++;

                if (startSpawnPoint >= _spawnPoints.Length)
                {
                    startSpawnPoint = 0;
                }
            }            

            yield return waitForSeconds;
        }
    }
}