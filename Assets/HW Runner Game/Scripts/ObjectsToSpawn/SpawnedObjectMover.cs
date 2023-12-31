using UnityEngine;

namespace HWRunnerGame
{
    public class SpawnedObjectMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
}