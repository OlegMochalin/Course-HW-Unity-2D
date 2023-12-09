using UnityEngine;

public class SquareMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.004f;
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed);
    }
}