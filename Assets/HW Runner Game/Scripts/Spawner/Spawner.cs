using System.Collections;
using UnityEngine;

namespace HWRunnerGame
{
    public class Spawner : ObjectsPool
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject[] _spawnObjectPrefabs;
        [SerializeField] private float _spawnDelay;

        private void Start()
        {
            Initialize(_spawnObjectPrefabs);
            StartCoroutine(SpawnObject());
        }

        private void SetObject(GameObject objectToSpawn, Vector3 spawnpoint)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = spawnpoint;
        }

        private IEnumerator SpawnObject()
        {           
            if (TryGetObject(out GameObject objectToSpawn))
            {
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetObject(objectToSpawn, _spawnPoints[spawnPointNumber].position);
            }

            yield return new WaitForSeconds(_spawnDelay);

            StartCoroutine(SpawnObject());
        }
    }
}