using UnityEngine;

public class CapsuleSizer : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _minSize = 1f;
    [SerializeField] private float _maxSize = 2f;

    private void Update()
    {
        transform.localScale = new Vector2(Mathf.PingPong(Time.time, _maxSize - _minSize) + _minSize, Mathf.PingPong(Time.time, _maxSize - _minSize) + _minSize);
    }
}