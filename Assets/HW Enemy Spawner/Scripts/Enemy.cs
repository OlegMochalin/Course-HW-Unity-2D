using UnityEngine;

[RequireComponent(typeof(EnemyToTargetMover))]
public class Enemy : MonoBehaviour
{
    private EnemyTarget _target;

    public void GetTarget(EnemyTarget target)
    {
        _target = target;
        GetComponent<EnemyToTargetMover>().GetTarget(_target);
    }
}