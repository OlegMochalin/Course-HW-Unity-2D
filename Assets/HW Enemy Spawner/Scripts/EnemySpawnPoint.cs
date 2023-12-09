using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;

    private EnemyTarget _enemyTarget;

    private void Start()
    {
        _enemyTarget = GetComponentInChildren<EnemyTarget>();
    }

    public void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, transform.rotation);
        enemy.GetTarget(_enemyTarget);
    }
}