using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemiesAmount = 12;
    [SerializeField] private float _spawnDelay = 2;

    private EnemySpawnPoint[] _spawnPoints;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForSeconds = new WaitForSeconds(_spawnDelay);
        int spawnPoint = 0;

        for (int i = 0; i < _enemiesAmount; i++)
        {
            _spawnPoints[spawnPoint].SpawnEnemy();

            if (spawnPoint < _spawnPoints.Length)
            {
                spawnPoint++;

                if (spawnPoint >= _spawnPoints.Length)
                {
                    spawnPoint = 0;
                }
            }            

            yield return waitForSeconds;
        }
    }
}