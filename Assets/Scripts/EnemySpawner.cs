using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private float _spawnTimeDelay = 2f;


    public void Start()
    {
        //StartCoroutine(spawnEnemy(_spawnTimeDelay, _enemyTemplate));
    }

    public IEnumerable spawnEnemy(float spawnTimeDelay, GameObject enemyTemplate)
    {        
        yield return new WaitForSeconds(spawnTimeDelay);
        GameObject newEnemy = Instantiate(enemyTemplate, Vector2.zero, Quaternion.identity);
        //StartCoroutine(spawnEnemy(spawnTimeDelay, enemyTemplate));
    }
}