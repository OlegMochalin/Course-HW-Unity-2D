using UnityEngine;

public class CircleMover : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minYPosition = -4f;
    [SerializeField] private float _maxYPosition = 4f;

    private void Update()
    {
        if (transform.position.y <= _minYPosition || transform.position.y >= _maxYPosition)
            _speed *= -1;

        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }
}