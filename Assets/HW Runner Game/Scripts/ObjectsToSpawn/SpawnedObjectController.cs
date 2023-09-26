using UnityEngine;

namespace HWRunnerGame
{
    public class SpawnedObjectController : MonoBehaviour
    {
        [SerializeField] private float _speed;

        void Update()
        {
            transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }
    }
}