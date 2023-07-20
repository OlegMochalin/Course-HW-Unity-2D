using UnityEngine;

public class EnemyToTargetMover : MonoBehaviour
{
    private EnemyTarget _target;
        
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 0.05f);
    }

    public void GetTarget(EnemyTarget target)
    {
        _target = target;
    }
}