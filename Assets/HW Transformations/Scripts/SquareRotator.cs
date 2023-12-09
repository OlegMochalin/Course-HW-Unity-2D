using UnityEngine;

public class SquareRotator : MonoBehaviour
{
    [SerializeField] private float _speed = 20f;

    private void Update()
    {
        transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}