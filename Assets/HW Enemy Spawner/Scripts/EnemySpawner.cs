using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

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
        int spawnPoint;

        for (int i = 0; i < _enemiesAmount; i++)
        {
            spawnPoint = Random.Range(0, _spawnPoints.Length);
            _spawnPoints[spawnPoint].SpawnEnemy();      

            yield return waitForSeconds;
        }
    }
}