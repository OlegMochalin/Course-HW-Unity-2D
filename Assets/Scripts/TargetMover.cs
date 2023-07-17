using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField] private Transform target;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 0.1f);
    }
}