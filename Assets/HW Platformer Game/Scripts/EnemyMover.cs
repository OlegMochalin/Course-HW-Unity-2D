using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Transform _patrolPath;
    [SerializeField] private float _speed = 2;

    private const string BatFlyAnimation = "Bat_fly";

    private Transform[] _pathPoints;
    private Animator _animator;
    private int _currentPoint;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _pathPoints = new Transform[_patrolPath.childCount];

        for (int i = 0;  i < _patrolPath.childCount; i++)
        {
            _pathPoints[i] = _patrolPath.GetChild(i);
        }
    }

    void FixedUpdate()
    {
        _animator.Play(BatFlyAnimation);

        Transform target = _pathPoints[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _pathPoints.Length)
            {
                _currentPoint = 0;
            }
        }
    }
}