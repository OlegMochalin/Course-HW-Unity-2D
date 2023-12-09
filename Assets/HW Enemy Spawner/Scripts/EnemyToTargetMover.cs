using UnityEngine;

public class EnemyToTargetMover : MonoBehaviour
{
    [SerializeField] private float _speed = 0.05f;

    private EnemyTarget _target;
        
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed);
    }

    public void GetTarget(EnemyTarget target)
    {
        _target = target;
    }
}