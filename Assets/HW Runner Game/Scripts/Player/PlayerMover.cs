using UnityEngine;

namespace HWRunnerGame 
{
    [RequireComponent(typeof(Player))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
                
        private Vector3 _targetPosition;
        private float _minYPosition = -3;
        private float _maxYPosition = 3;
        private float _stepSize = 1;

        private void Start()
        {
            _targetPosition = transform.position;
        }

        private void FixedUpdate()
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                MoveUp();
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                MoveDown();
            }
        }

        private void Update()
        {
            if (transform.position != _targetPosition)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
            }
        }

        private void MoveUp()
        {
            if (_targetPosition.y + _stepSize <= _maxYPosition)
                _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + _stepSize);
        }

        private void MoveDown()
        {
            if (_targetPosition.y - _stepSize >= _minYPosition)
                _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y - _stepSize);
        }
    }
}