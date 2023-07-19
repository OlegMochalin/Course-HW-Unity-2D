using UnityEngine;

[RequireComponent (typeof(Enemy))]
public class EnemyToTargetMover : MonoBehaviour
{
    private EnemyTarget _target;
        
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.GetComponent<Transform>().position, 0.05f);
    }

    public void GetTarget(EnemyTarget target)
    {
        _target = target;
    }
}