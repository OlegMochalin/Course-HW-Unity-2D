using UnityEngine;

namespace HWRunnerGame
{
    public class Spawner : ObjectsPool
    {
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private GameObject[] _spawnObjectPrefabs;
        [SerializeField] private float _spawnDelay;

        private float _timeGone = 0;

        private void Start()
        {
            Initialize(_spawnObjectPrefabs);
        }

        private void Update()
        {
            _timeGone += Time.deltaTime;

            if (_timeGone >= _spawnDelay)
            {
                if (TryGetObject(out GameObject objectToSpawn))
                {
                    _timeGone = 0;

                    int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                    SetObject(objectToSpawn, _spawnPoints[spawnPointNumber].position);
                }                
            }
        }

        private void SetObject(GameObject objectToSpawn, Vector3 spawnpoint)
        {
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = spawnpoint;
        }
    }
}