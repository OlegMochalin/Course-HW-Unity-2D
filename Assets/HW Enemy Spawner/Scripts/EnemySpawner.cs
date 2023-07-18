using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private int _enemiesAmount = 10;
    [SerializeField] private float _spawnDelay = 2;

    private EnemySpawnPoint[] _spawnPoints;

    void Awake()
    {
        _spawnPoints = GetComponentsInChildren<EnemySpawnPoint>();

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        var waitForSeconds = new WaitForSeconds(_spawnDelay);
        int startSpawnPoint = 0;

        for (int i = 0; i < _enemiesAmount; i++)
        {            
            Instantiate(_enemyPrefabs[0], _spawnPoints[startSpawnPoint].GetComponent<Transform>().position, transform.rotation);

            if (startSpawnPoint < _spawnPoints.Length - 1)
                startSpawnPoint++;
            else
                startSpawnPoint = 0;

            Debug.Log(Time.time);

            yield return waitForSeconds;
        }
    }
}